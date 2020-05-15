$(document).mouseup(function (e)
  {
  var container = $(".categoriesBtn");
  var container1 = $(".categories ");
  var container2 = $(".categories  *");
  if (!container.is(e.target)  && 
	!container1.is(e.target)    && 
	!container2.is(e.target)  && 
	container.has(e.target).length === 0) 
 	 {    
  		$(".categories ").removeClass("opens");
  	 } 
	});

$(document).mouseup(function (e)
  {
  var container = $(".mobnav");
  var container1 = $(".menuMobile");
  var container2 = $(".menuMobile  *");
  if (!container.is(e.target)  && 
	!container1.is(e.target)    && 
	!container2.is(e.target)  && 
	container.has(e.target).length === 0) 
 	 {    
  		$(".menuMobile").removeClass("opens");
  	 } 
	});

/*Prof Banner Next Previous*/
$('.profSlider').owlCarousel({
    loop:true,
    margin:10,
    nav:true,
	items:4,
	autoplayTimeout:5000,
    smartSpeed:500,
	autoplay:true,
	responsive:{
        0:{
            items:1
        },
        639:{
            items:2
        },
        767:{
            items:3
        },
		1050:{
            items:4
        }
    }
})

var proff = $('.profSlider');
proff.owlCarousel();
$('.right-symbol').click(function() {
    proff.trigger('next.owl.carousel');
})
$('.left-symbol').click(function() {
    proff.trigger('prev.owl.carousel', [300]);
})

/*-------- listing tab------*/
	$(".tabs ul li a").on("click" , function(e){
		 e.preventDefault();
		var weddInd = $(this).attr('href');
		$(".tabContent").hide(0);
		$(weddInd).show(0);
		$(".tabs ul li a").removeClass('active');
		$(this).addClass('active');
	});
	
/*-------- admin tab------*/
	$(".msgList ul li a").on("click" , function(e){
		 e.preventDefault();
		var weddInd = $(this).attr('href');
		$(".tabsection1").hide(0);
		$(weddInd).show(0);
		$(".msgList ul li a").removeClass('active');
		$(this).addClass('active');
	});


/*clientSaySlider*/
$('.clientSaySlider').owlCarousel({
    loop:true,
    margin:20,
    nav:true,
	items:2,
	autoplayTimeout:5000,
    smartSpeed:800,
	autoplay:true,
	responsive:{
        0:{
            items:1
        },
        767:{
            items:2
        }
    }
})

var clientSay = $('.clientSaySlider');
clientSay.owlCarousel();
$('.right-icon').click(function() {
    clientSay.trigger('next.owl.carousel');
})
$('.left-icon').click(function() {
    clientSay.trigger('prev.owl.carousel', [300]);
})

$(document).ready(function(){
  $(".langDropdown").click(function(){
		$(".langdropList").stop().slideToggle(300);
  });
  
  	//Hover menuBar
 	 $(".mobnav").click(function(){
	 $(".menuMobile").toggleClass("opens");
		$("body").toggleClass("bodyHidden");
 	});
	 
	 //Hover browseCategories
	 $(".categoriesBtn").click(function(){		
		$(".categories").toggleClass("opens");
  	 });
	 
	 $(".closeBtn").click(function(){
		$(".categories").removeClass("opens"); 		
	 });
		 
	  $(".subcat a").click(function(){
		if($(window).width() <= 767){
			

		if(!$(this).hasClass("open2")){
		$(".subcat a").next().slideUp(300);
		$(".subcat a").removeClass("open2");
		$(this).next().slideDown(300);
		$(this).addClass("open2");
			}
			else
			{
				$(this).next().slideUp(300);
				$(this).removeClass("open2");
			}
		}
  	 });
    $(".loginpopup").click(function () {
        
		$("#loginpopup").fadeIn(400);
		$("body").addClass("loghiddens");
		$(".backBg").fadeIn(300);
	   });

	 $(".closepop").click(function(){
	    $("#loginpopup").fadeOut(400);
	    $("body").removeClass("loghiddens");
	    $("#loginpopup").fadeOut(400);
	 });
	 
	 /****Mobilemenu dashboard******/
 	 $(".dashmobileMenu a").click(function(){
	 $(".dashmenuList").slideToggle("300");
 	 });
		 
});

$(window).scroll(function(){
		if($(window).scrollTop() >1)
	{
		$("header").addClass("active");
	}
	else
	{
		$("header").removeClass("active");
	}
});

/*--------------Login popup--------------*/
	

//$(document).ready(function() {
//$(".scroll").niceScroll({cursorborder:"",cursorcolor:"#005faa",boxzoom:true});
//});





