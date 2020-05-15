(function($){
    $(document).ready(function(){		//when DOM is ready
        soulage.init();
    });
	window.onload = function () {		//when window content is fully loaded
		soulage.initImageResize();
	}
	$(window).resize(function() {
		soulage.initImageResize();
		//soulage.initSingleProductImageSlider();
		soulage.adjustCollectionItemHeight();
		soulage.initFooter();
	});
})(jQuery);


var soulage = {
	activeQuickshop: null,
	currentVariantOptions: null,
	productImageAlts: null,
	slideChanged: false,
	assoc_product_variant_image: false,
	resizableImages: [
		'.product-image-resizable',
		'.product-image-resizable-small',
		'.collection-image-resizable',
		'.product-image-resizable-344x344',
		'.product-image-resizable-large',
		'.product-image-resizable-155x155',
		'.product-image-resizable-94x94'
	],
	init: function() {
		this.initScrollTop();
		this.initQuickShop();
		this.initHomepageSlider();
		this.initSingleProductImageSlider();
		this.initSingleProductDescriptionTabs();
		this.initFormElements();
		this.hideResizableImages();
		this.initNavigationSelector();
		this.initCommentForm();
		this.initCart();
		this.initAccountLogin();
		this.initAddressManage();
		this.initProductLightbox();
		this.adjustCollectionItemHeight();
		this.initFooter();
		this.initCurrenctSelector();
	},
	initScrollTop: function() {
		$('.back-to-the-top').click(function () {
			$('body,html').animate({
				scrollTop: 0
			}, 400);
			return false;
		});
	},
	initCurrenctSelector: function() {
		$('.current-currency').click(function() {
			$('#currencies').trigger('click');
		});
		return false;
	},
	initFooter: function() {
		var mainfooterwrapper = $('.main-footer-wrapper');
		$('.main-content-wrapper').css({ paddingBottom: mainfooterwrapper.height()+100 });
	},
	initQuickShop: function() {		
			
		//	//get and position content
		//	var item = $(this).parents('.__collection-item');
		//	var quickShopContent = $('.quick-shop-content', item).html();	//store quick shop markup in variable
		//	soulage.activeQuickshop = $('.quick-shop-content', item).attr('id');
		//	$('.quick-shop-content', item).html('');						//remove original
		//	$('.quick-shop').html(quickShopContent);
			
		//	soulage.adjustQuickShopPopupPosition();
		//	var productId = soulage.activeQuickshop.match(/\d+/g);
		//	if( typeof window['productSelect' + productId] != "undefined" && $('.selector-wrapper', quickShopContent).length == 0 )
		//	{
		//		//load select event handlers
		//		new Shopify.OptionSelectors( window['productSelect' + productId], { product: window['productData' + productId], onVariantSelected: selectCallback });
		//		soulage.customFormElements( window['productFormElement' + productId] );
		//	}
			
		//	//load and resize image
		//	var placeholder = $('.placeholder-span', '.quick-shop');
		//	var quickImage = new Image();
		//	quickImage.onload = function() {
		//		placeholder.parent().append(quickImage);
		//		placeholder.remove();
			
		//		var params = {
		//			maxWidth: 344,
		//			maxHeight: 344,
		//			currWidth: quickImage.width,
		//			currHeight: quickImage.height
		//		};	
			
		//		soulage.resizeImage($('.product-image-resizable-344x344', '.quick-shop'), params);		
		//	};
		//	quickImage.src = placeholder.attr('data-src');
		//	quickImage.className += placeholder.attr('data-class');
		//	quickImage.alt = placeholder.attr('data-alt');
			
		//	//fade in
		//	$('.lightbox').show();	//IE does not allow to fadein transparent stuff
		//	$('.quick-shop').fadeIn(350);			

		//	return false;
		//});
        $(window).resize(function () {
            //fade in
            $('.lightbox').show();	//IE does not allow to fadein transparent stuff
            $('.quick-shop').fadeIn(350);
			soulage.adjustQuickShopPopupPosition();
        });
        $('.lightbox, .close').live('click', function () {
            soulage.closeQuickShopPopup();
            return false;
        });
    },

	adjustQuickShopPopupPosition: function() {
		$('.quick-shop').css({
			position: 'fixed',
			left: ($(window).width() - $('.quick-shop').outerWidth())/2,
			top: ($(window).height() - $('.quick-shop').outerHeight())/2
		});	
	},
	closeQuickShopPopup: function() {
		$('.quick-shop').fadeOut(350);			//close popup
		$('.lightbox').hide();
		var quickShopItem = $('#' + soulage.activeQuickshop);
		quickShopItem.html( $('.quick-shop').html() );		//replace content
		$('.quick-shop').html('');							//clear
		soulage.activeQuickshop = null;
	},
	initHomepageSlider: function() {
		if($('.template-index').length > 0) {	
			$('#hompage-slider_content').cycle({
				fx: 'scrollHorz',
				speed: '600',
				timeout: '5000',
				prev:   '.previous', 
				next:   '.next',
				pager: '#pager',
				activePagerClass: "active",
				easing: 'swing',
				slideResize: 0,
				containerResize: 1,
				slideExpr: '.item',
				pagerAnchorBuilder: function(idx, slide) {  return ''; }
			});

            if($('#hompage-slider_content').children('.item').length <= 1)
            {
                $('#hompage-slider_content .blank-item').hide();
                $('.homepage-slider .navigation').hide();
            }

			$('.navigation .bullet').click(function(){
				var index = $('.navigation #pager a').index($(this));
				$('#hompage-slider_content').cycle(index);
				return false;
			});
		}
	},
	initImageResize: function() {
		
		var window_w = $(window).width();	
		
		if(window_w > 767 && window_w < 959 ) {	//ipad
			this.resizeImageCollection($('.product-image-resizable'), 214, 214);
			this.resizeImageCollection($('.product-image-resizable-large'), 320, 320);
			this.resizeImageCollection($('.collection-image-resizable'), 214, 214);
		} else if(window_w <= 767) {	//iphone
			this.resizeImageCollection($('.product-image-resizable'), 139, 139);
			this.resizeImageCollection($('.product-image-resizable-large'), 294, 294);
			this.resizeImageCollection($('.collection-image-resizable'), 139, 139);
		} else {	//full
			this.resizeImageCollection($('.product-image-resizable'), 214, 214);
			this.resizeImageCollection($('.product-image-resizable-large'), 470, 470);
			this.resizeImageCollection($('.collection-image-resizable'), 294, 294);
		}
		
		this.resizeImageCollection($('.product-image-resizable-small'), 60, 60);
		this.resizeImageCollection($('.product-image-resizable-344x344'), 344, 344);
		this.resizeImageCollection($('.product-image-resizable-155x155'), 155, 155);
		this.resizeImageCollection($('.product-image-resizable-94x94'), 94, 94);
	},
	resizeImageCollection: function(collection, maxWidth, maxHeight) {
		if(collection.length > 0) {
			collection.each(function() {				
				var params = {
					maxWidth: maxWidth,
					maxHeight: maxHeight
				};
				soulage.resizeImage($(this), params);
			});
		}
	},
	resizeImage: function(item, params) {
				
		maxWidth = params.maxWidth;
		maxHeight = params.maxHeight;
		item.attr('style', '');	//reset previous styles
		
		if( params.currHeight != null) { height = params.currHeight; }
		else { height = item.height(); }
		
		if( params.currWidth != null) { width = params.currWidth; }
		else { width = item.width(); }
				
		//resize
		if(width >= height && height > maxHeight) {
			item.css('height', maxHeight + 'px');
			width = width * (maxHeight / height);
			height = maxHeight;
			
		} else if(width < height && width > maxWidth) {
			item.css('width', maxWidth + 'px');
			height = height * (maxWidth / width);
			width = maxWidth;
		}
		
		//reposition
		if(width > 0) { 
			var diff = parseInt((maxWidth - width)/2);
			item.css('position', 'absolute');
			item.css('left', diff + 'px');
		}
		if(height > 0) { 
			var diff = parseInt((maxHeight - height)/2);
			item.css('position', 'absolute');
			item.css('top', diff + 'px');
		}
		
		item.show();
	},
	initSingleProductImageSlider: function() {
		if($('.template-product').length > 0) {
						
			$('#single-product-slider').cycle({
				fx: 'scrollHorz',
				speed: '600',
				timeout: 0,
				easing: 'swing',
				slideResize: 0,
				containerResize: 1,
				slideExpr: '.image'
			});

			var navBtns = $('.main-item-wrapper .image-wrapper-4')
			navBtns.click(function(){
				var index = navBtns.index($(this));
				navBtns.removeClass('active');
				$(this).addClass('active');
				soulage.slideChanged = false;
				if(soulage.assoc_product_variant_image)
				{
					soulage.singleProductImageSlideVariantChange(index);					
				}
				if(!soulage.slideChanged)
				{
					$('#single-product-slider').cycle(index);
				}
				return false;
			});
		}
	},
	singleProductVariantImageSlide: function(options) {		
		soulage.slideChanged = false;
		if(soulage.currentVariantOptions == null)
		{
			soulage.currentVariantOptions = options;
			soulage.productImageAlts = new Array();
			$('.slider-navigation-thumbs img').each(function(){
				soulage.productImageAlts.push($(this).attr('alt')); 
			});
		}
		else
		{
			var old = soulage.currentVariantOptions;
			soulage.currentVariantOptions = options;
			
			for(i = 0; i <= 3; i++)
			{
				if(old[i] !== options[i])
				{
					var pos = jQuery.inArray(options[i], soulage.productImageAlts);
					if(pos > -1 )
					{
						$('#single-product-slider').cycle(pos);
						soulage.slideChanged = true;
						navBtns = $('.main-item-wrapper .image-wrapper-4');
						navBtns.removeClass('active');
						navBtns.eq(pos).addClass('active');
					}
				}
			}
		}
	},
	singleProductImageSlideVariantChange: function(index) {
		var variant = soulage.productImageAlts[index];
		var selects = $('form.variants .single-option-selector');
		var match = null;
		selects.each(function(){
			match = $(this).children('option[value="'+ variant +'"]');
			if(match.length > 0) {
				$(this).val(variant).trigger('change');
				return false;
			}
		});
	},
	initSingleProductDescriptionTabs: function() {
		if($('.template-product').length > 0) {
						
			//cache selectors
			var navBtns = $('.button-navigation a');
			var descrItems = $('.main-item-wrapper .description .items .item');
			navBtns.hide();
						
			if(descrItems.hasClass('table-only')) {
				if( descrItems.find('table').length > 0) {	//if there is specs table
					//filter content
					descrItems.each(function() {
						if($(this).hasClass('text-only'))
						{
							$('table', $(this)).remove();
						}
						if($(this).hasClass('table-only'))
						{
							var tempTable = $('table', $(this));
							$(this).empty();
							$(this).append(tempTable);
						
							//set equal heights
							var maxHeight = 0;
							descrItems.each(function() {
								if($(this).height() > maxHeight)
								{
									maxHeight = $(this).height();
								}
							});
							$('.main-item-wrapper .description .items .item').css('height', maxHeight);
						}
					});

					$('#description_slider').cycle({
						fx: 'scrollHorz',
						speed: '600',
						timeout: 0,
						easing: 'swing'
					});

					navBtns.click(function(){
						var index = navBtns.index($(this));
						navBtns.removeClass('active');
						$(this).addClass('active');
						$('#description_slider').cycle(index);
						return false;
					});
					
					navBtns.show();
				} else {
					//if no table found
					$('.table-only').remove();	
				}
			}
		}
	},
	initFormElements: function() {
		if($("select:not(.no-uniform)").length > 0) {
			$("select:not(.no-uniform)").uniform();
		}
		
		$('.product-purchase-btn').click(function() {
			if($(this).attr('disabled') != 'disabled')
			{
				var productId = $(this).parents('.product-container').attr('id');
				productId = productId.match(/\d+/g);
				$('#product-actions-' + productId).submit();
			}
			return false;
		});
		
		$('.form-submit-btn').click(function(){
			$(this).parents('form').submit();
		});
	},
	customFormElements: function(selector) {
		$(selector).uniform();
	},
	hideResizableImages: function() {
		for(i in this.resizableImages) {
			$(this.resizableImages[i]).hide();
		}
	},
	initNavigationSelector: function() {
		var selector = $('.navigationSelector');
		if(selector.length > 0)
		{
			selector.change(function(){
				window.location = $('option:selected', $(this)).attr('value');
			});
		}
    },
    initNavigationSelector1: function () {
        var selector = $('.navigationSelector1');
        if (selector.length > 0) {
            selector.change(function () {
                window.location = $('option:selected', '/Home/catalog/' + $(this)).attr('value');
            });
        }
    },
	initCommentForm: function() {
		if($('.template-article').length > 0)
		{
			$('#comment-submit').click(function(){
				var form = $(this).parents('form');
				form.submit();
			});
		}
	},
	initCart: function() {
		if($('.template-cart').length > 0)
		{
			$('#cart_submit').click(function(){
				$('.__checkout-btn').trigger('click');
				return false;
			});
			
			$('#cart_update').click(function(){
				$('.__update-btn').trigger('click');
				return false;
			});
			
			
			// + 1 quantity
			$('.cart-items .quantity .plus').click(function(){
				var quantity = $(this).siblings('input[type=text]');
				var newQuantity = parseInt(quantity.val()) + 1;
				quantity.val(newQuantity);
				return false;
			});
			
			// - 1 quantity
			$('.cart-items .quantity .minus').click(function(){
				var quantity = $(this).siblings('input[type=text]');
				var oldQuantity = parseInt(quantity.val());
				if(oldQuantity > 1)
				{
					var newQuantity = oldQuantity - 1;
					quantity.val(newQuantity);
				}
				return false;
			});
			
			//allow only numbers to be entered in quantity box
			$('.cart-items .quantity input[type=text]').keydown(function(event) {
		        // Allow: backspace, delete, tab and escape
		        if ( event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27
			 		|| 
		            (event.keyCode == 65 && event.ctrlKey === true) 
					|| 
		            (event.keyCode >= 35 && event.keyCode <= 39)) {
		                 return;
		        }

		        // Ensure that it is a number and stop the keypress
		        if ((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105 )) {
		            event.preventDefault(); 
		        }   
			});
		}
	},
	initAccountLogin: function() {
		if($('.template-customers-login').length > 0)
		{
			if (window.location.hash == '#recover') {
				$('#login_form').hide();
				$('#password_recovery').show();
			}
			
			$('#forgot_password').click(function() {
				$('#login_form').fadeOut(200, function(){
					$('#password_recovery').fadeIn(200);
				});
				return false;
			});
		
			$('#login').click(function() {
				$('#password_recovery').fadeOut(200, function(){
					$('#login_form').fadeIn(200);
				});
				return false;
			});
		
			$('#login_submit').click(function() {
				$('#customer_login').submit();
				return false;
			});
		
			$('#recover_submit').click(function() {
				$(this).parents('form').submit();
				return false;
			});
		}
	},
	initAddressManage: function() {
		if($('.template-customers-addresses').length > 0)
		{
			
			$('.edit-address-btn').click(function(){
				var editForm = 'edit_' + $(this).parents('.row').attr('id');				
				$('#' + editForm ).slideDown(300);
				return false;
			});
			
			$('.address-edit-form-cancel').click(function(){
				$(this).parents('.address-edit-form').slideUp(300);
				return false;
			});
			
		}
	},
	initProductLightbox: function() {
		if($('.template-product').length > 0)
		{
			$('.lightbox-launcher').click(function(){
				
				var elem = $(this);
				var imgSrc = elem.attr('href');
				$('.lightbox').show();
				
				var productImage = new Image();
				productImage.onload = function() {
					$('.quick-shop').html(productImage);
					$('.quick-shop').append('<a href="#" class="close"></a>');
					soulage.adjustQuickShopPopupPosition();
					$('.quick-shop').fadeIn(350, function(){
						soulage.adjustQuickShopPopupPosition();
					});
				};
				productImage.src = imgSrc;
				
				return false;
			});
			
			$('.lightbox, .close, .quick-shop > img').live('click', function(){
				soulage.closeQuickShopPopup();
				return false;
			});

			$(window).resize(function(){
				soulage.adjustQuickShopPopupPosition();
			});
		}
	},
	adjustCollectionItemHeight: function() {
		var width = $(window).width();

		/***** 4 columns *****/
		var items = $('.items .item-block-1');
		if(items.length > 0)
		{	
			var columns = 4;	//normal
			if(width < 959 && width > 768) { columns = 3; }	//tablet
			if(width < 768) { columns = 2; }	//smartphone

			soulage.resizeRowItemHeight(items, columns);
		}

		/***** 3 columns *****/
		var items = $('.items .item-block-2');
		if(items.length > 0)
		{	
			var columns = 3;	//normal
			if(width < 768) { columns = 2; }	//smartphone
			soulage.resizeRowItemHeight(items, columns);
		}
	},
	resizeRowItemHeight: function(items, columns) {
		var chunks = chunk(items, columns);

		for(var row in chunks)
		{
			chunks[row].height(''); //reset previous height
			var maxHeight = Math.max.apply(null, chunks[row].map(function ()
			{
			    return $(this).height();
			}).get());
			chunks[row].height(maxHeight);
		}
	}
}

function chunk (arr, len) {

  var chunks = [],
      i = 0,
      n = arr.length;

  while (i < n) {
    chunks.push(arr.slice(i, i += len));
  }

  return chunks;
}