// Start enhancement of function.js
$(document).ready(function () {
    if ($(".scroll")[0]) {
        // Do something if class exists
        $(".scroll").niceScroll({ cursorborder: "", cursorcolor: "#005faa", boxzoom: true });
    }
});
// End enhancement of function.js

// Mozilla Calender
//webshims.setOptions('forms-ext', { types: 'date' });
//webshims.polyfill('forms forms-ext');

function ajax_call(PageURL, PostData, OnSuccessFunction, OnErrorFunction) {
    show_progress();
    $.ajax({
        type: "POST",
        url: PageURL,
        data: PostData,
        async: false,
        contentType: "application/json; charset=utf-8",
        success: OnSuccessFunction,
        error: OnErrorFunction
    }).done(hide_progress);
}

function show_progress() {
    var maindiv = document.createElement('div');
    maindiv.id = 'functionjsprogressdiv';
    var divprogress = document.createElement('div');
    divprogress.setAttribute('style', 'position: fixed; top: 0px; left: 0px; background-color: white; width: 100%; height: 100%; z-index: 99999; opacity: 0.4; filter: alpha(opacity=80); -moz-opacity: 0.8; -khtml-opacity: 0.8; -moz-opacity: 0.8; padding-top: 200px;text-align:center;');
    var divprogressimg = document.createElement('div');
    divprogressimg.setAttribute('style', 'width: 100%; position: fixed; height: 1px; top: 2px; left: 0px; z-index: 999999; padding-top: 300px;text-align:center;');
    divprogressimg.innerHTML = '<img alt="" src="/images/CandidateProfileLoader.gif" width="10%"  style="opacity:0.6"/>';
    maindiv.appendChild(divprogress);
    maindiv.appendChild(divprogressimg);
    document.body.appendChild(maindiv);
}

function hide_progress() {
    if (document.getElementById('functionjsprogressdiv') != null) {
        document.body.removeChild(document.getElementById('functionjsprogressdiv'));
    }
}

function InitializeMCEEditor() {
    tinyMCE.init({
        mode: "textareas",
        editor_selector: "MCEEditor",
        theme: "simple",
        theme_advanced_toolbar_location: "top",
        theme_advanced_statusbar_location: "bottom",
        theme_advanced_resizing: true
    });
}

function InitializeAdvanceMCEEditor() {
    tinyMCE.init({
        // General options
        mode: "textareas",
        editor_selector: "MCEEditor",
        theme: "advanced",
        plugins: "autolink,lists,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,inlinepopups,autosave",

        // Theme options
        theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect",
        theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
        theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
        theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak,restoredraft",
        theme_advanced_toolbar_location: "top",
        theme_advanced_toolbar_align: "left",
        theme_advanced_statusbar_location: "bottom",
        theme_advanced_resizing: true,

        // Example content CSS (should be your site CSS)
        //  content_css: "css/content.css",

        // Drop lists for link/image/media/template dialogs
        template_external_list_url: "lists/template_list.js",
        external_link_list_url: "lists/link_list.js",
        external_image_list_url: "lists/image_list.js",
        media_external_list_url: "lists/media_list.js",

        // Replace values for the template plugin
        template_replace_values: {
            username: "Some User",
            staffid: "991234"
        }
    });
}

function checkFileExtension(_input) {
    var FileExtension = _input.substring(_input.lastIndexOf('.') + 1).toLowerCase();
    return FileExtension;
}

// Check only numeric Or Character on key press
function onlynumericOrCharacter(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 8 || charCode == 127 || charCode == 32 || charCode == 0 || charCode == 11
            || charCode == 13 || (charCode >= 48 && charCode <= 57) || charCode == 118
        )
            return true;
        else {
            swal("Please enter valid inputs.", "", "error");
            return false;
        }
    }
    catch (err) {
        alert(err.Description);
    }
}

// Check illegal characters on key press
function OnlyLegalCharacters(e, t) {
    $('input[type=submit]').prop("disabled", false);
    $('input[type=submit]').css("cursor", "pointer");
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if (charCode != 60 && charCode != 62)
            return true;

        else {
            swal("Please enter valid inputs.", "", "error");
            return false;
        }
    }
    catch (err) {
        alert(err.Description);
    }
}

// Check illegal characters on submit and prevent form posting
function CheckValidInput(submitElement) {
    var IsValidData = true;
    $(submitElement).prop("disabled", true);
    $(submitElement).css("cursor", "default");
    var FormInputFields = $('input[type=text]').each(function () {
        if (IsValidData)
            IsValidData = CheckLegalCharactersOnSubmit(this);
    });
    if (IsValidData) {
        if (!$('form').valid()) {
            $('input[type=submit]').prop("disabled", false);
            $('input[type=submit]').css("cursor", "pointer");
            IsValidData = false;
        }
        else {
            $(submitElement).prop("disabled", true);
            $(submitElement).css("cursor", "default");
            $(submitElement).prop("value", "Please wait...");
            IsValidData = true;
            $('form').submit();
        }
    }
    return IsValidData;

}

// Check illegal characters on submit
function CheckLegalCharactersOnSubmit(e, t) {
    try {
        if (($(e).val().indexOf('<') != -1) || ($(e).val().indexOf('>') != -1)) {
            swal("Please enter valid inputs.", "", "error");
            return false;
        }
        else
            return true;
    }
    catch (err) {
        alert(err.Description);
        return false;
    }
}

function ValidateImageWithSize(element, targetElement, width, height) {
    var _URL = window.URL || window.webkitURL;
    var file, img;
    if ((file = element.files[0])) {
        img = new Image();
        img.onload = function () {
            if (this.width != width || this.height != height) {
                $(element).val('');
                swal('', 'Invalid image dimensions. Required dimensions are' + width + '*' + height, 'error');
            }
            else
                readImageURL(element, targetElement);
        };
        img.onerror = function () {
            alert("not a valid file: " + file.type);
        };
        img.src = _URL.createObjectURL(file);
    }
}

function readImageURL(controlID, imageID) {
    var ValidImage = 0;
    var CheckFileType = checkFileExtension($(controlID).val());
    if (CheckFileType == "png" || CheckFileType == "jpg" || CheckFileType == "jpeg" || CheckFileType == "gif") {
        if (controlID.files && controlID.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $(imageID).attr('src', e.target.result);
            };
            reader.readAsDataURL(controlID.files[0]);
        }
        ValidImage = CalculateFileSize($(controlID));
    }
    else {
        ValidImage = 1;
        // alert('Invalid image format');
    }

    if (ValidImage == 1)
        swal('', 'Invalid image format', 'error');
    //  alert('Invalid image format');
    if (ValidImage == 2)
        swal('', 'Maximum size of uploaded content is 2 MB', 'error');
    // alert('Please select an image of size < 4MB');
}

function CalculateFileSize(inputId) {
    var ValidImage = 0;
    var iSize = ($(inputId)[0].files[0].size / 1024);
    if (iSize / 1024 > 1) {
        if (((iSize / 1024) / 1024) > 1) {
            iSize = (Math.round(((iSize / 1024) / 1024) * 100) / 100);
        }
        else {
            iSize = (Math.round((iSize / 1024) * 100) / 100)
            if (iSize > 2)
                ValidImage = 2;
        }
    }
    else {
        iSize = (Math.round(iSize * 100) / 100)
    }
    return ValidImage;
}

function SweetAlertDeleteConfirmation(msgtype, msgtitle, message, OnConfirmClick, SuccessDeleteMsg, OnCancelClick, CancelMsg, ActionUrl, ItemIdToDelete) {
    swal({
        title: msgtitle,
        text: message,
        type: msgtype,
        showCancelButton: true,
        confirmButtonColor: '#DD6B55',
        confirmButtonText: 'Yes, I am sure!',
        cancelButtonText: "No, cancel it!",
        closeOnConfirm: false,
        closeOnCancel: false
    },
        function (isConfirm) {
            
            if (isConfirm) {
                var IsDeleted = DeleteFunction(ActionUrl, ItemIdToDelete);
                if (IsDeleted) {
                    swal({
                        title: '',
                        text: SuccessDeleteMsg,
                        type: 'success'
                    }, function () {
                        location.reload();
                    });
                }
                else {
                    swal("An error occured", "", "error");
                }

            } else {
                swal("Cancelled", CancelMsg, "error");
            }
        });
}



function DeleteFunction(ActionUrl, ItemIdToDelete) {
    var Status = true;
    url = ActionUrl;
    
    $.ajax({
        url: url,
        data: { id: ItemIdToDelete },
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) { 
            var re = (response);
            if (re == 1) {
                Status = true;
            }
            else if (re == 0) {
                Status = false;
            }
        },
        error: function (response) {
            Status = false;
        }
    })
    
    return Status;
}

var FooterSelectedElement = $('a[href="' + window.location.pathname.toLowerCase() + '"]');
if ($(FooterSelectedElement).parent().parent().parent().attr("class") == "ftrLeft fl")
    FooterSelectedElement.addClass('active');

var DashboardSelectedElement = $('a[href="' + window.location.pathname.toLowerCase() + '"]');
if ($(DashboardSelectedElement).parent().parent().parent().attr("class") == "dashmenuList")
    DashboardSelectedElement.parent().addClass('active');


function ValidateSearchAndSubmit(element) {
    var IsValidInput = CheckLegalCharactersOnSubmit($('#searchKey'));
    if (IsValidInput)
        return true;
    else return false;
    //  $(element).parent().parent().submit();
}

function showfilepreview(input, targetElement, elem) {
    var Extension = checkFileExtension($(input).val());
    if (input.files && input.files[0]) {
        if (Extension == "pdf" || Extension == "docx" || Extension == "doc" || Extension == "jpg" || Extension == "jpeg" || Extension == "png") {
            if (CalculateFileSize(input) == 2)
                swal('', 'Please select an image of size < 2MB', 'error');
            else
                targetElement.val(input.files[0].name);
        }
        else {
            swal('', 'Invalid document format', 'error');
        }
    }
}


function CheckAndSumbitValidForm(submitElement) {
    show_progress();
    $(submitElement).closest("form");
    // $('input[type=submit]').closest("form");
    var IsValidData = true;
    $(submitElement).prop("disabled", true);
    $(submitElement).css("cursor", "default");
    if (IsValidData) {
        if (!$(submitElement).closest("form").valid()) {
            $('input[type=submit]').prop("disabled", false);
            $('input[type=submit]').css("cursor", "pointer");
            IsValidData = false;
            hide_progress();
        }
        else {
            $(submitElement).prop("disabled", true);
            $(submitElement).css("cursor", "default");
            $(submitElement).prop("value", "Please wait...");
            IsValidData = true;
            $(submitElement).closest("form").submit();
        }
    }
    return IsValidData;

}
function convertDateToActualFormat(input) {

    var datePart = input.match(/\d+/g);
    var day = datePart[0]
    var month = datePart[1]
    var month = datePart[1]
    var year = datePart[2];
    return month + '/' + day + '/' + year;
}

function CompareDates(FromDate, ToDate) {
    debugger
    //date1 = convertDateToActualFormat(FromDate.val());
    //date2 = convertDateToActualFormat(ToDate.val());
    // var diff = DifferenceTwoDays(FromDate.val(),ToDate.val());
    if (Date.parse(new Date(FromDate.val())) > Date.parse(new Date(ToDate.val()))) {
        // if (Date.parse(new Date(FromDate.val())) > Date.parse(new Date(ToDate.val()))) {
        // if (diff < 0) {
        swal('', 'Invalid selected date range', 'error');
        return false;
    }
    else return true;
}

function IsValidEmailAddress(emailAddress) {
    var pattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
    var result = pattern.test(emailAddress);
    return result;
}

function SweetAlertAddConfirmation(msgtype, msgtitle, message, OnConfirmClick, SuccessAddMsg, OnCancelClick, CancelMsg, ActionUrl, ItemIdToAdd) {
    swal({
        title: msgtitle,
        text: message,
        type: msgtype,
        showCancelButton: true,
        confirmButtonColor: '#DD6B55',
        confirmButtonText: 'Yes, I am sure!',
        cancelButtonText: "No, cancel it!",
        closeOnConfirm: false,
        closeOnCancel: false
    },
        function (isConfirm) {
            
            if (isConfirm) {
                var IsAdded = AddFunction(ActionUrl, ItemIdToAdd);
                if (IsAdded) {
                    swal({
                        title: '',
                        text: SuccessAddMsg,
                        type: 'success'
                    }, function () {
                        location.reload();
                    });
                }
                else {
                    swal("An error occured", "", "error");
                }

            } else {
                swal("Cancelled", CancelMsg, "error");
            }
        });
}

function AddFunction(ActionUrl, ItemIdToAdd) {
    
    var Status = true;
    url = ActionUrl;
    $.ajax({
        url: url,
        data: { itemId: ItemIdToAdd },
        cache: false,
        type: "POST",
        success: function (response) {
            var re = (response);
            if (re == 1) {
                Status = true;
            }
            else if (re == 0) {
                Status = false;
            }
        },
        error: function (response) {
            Status = false;
        }
    })
    return Status;
}

function getProducts(ID) {
    
    $("#quickshop").html('');
    $.ajax({
        url: '/Home/GetProduct',
        data: { id: ID },
        type: 'GET',
        success: function (res) {
            $("#quickshop").html(res);
        },
        error: function (err) {
            console.log(err);
        }
    })

    //fade in
   
    $("#quickshop").fadeIn(400);
    $(".quick-shop-trigger").fadeIn(300);
    document.getElementById('lightbox').style.display = 'block';
}


function getCart() {
    $("#_cartDiv").html('');
    $.ajax({
        url: '/Shopping/_Cart',
        //data: { id: categoryid },
        type: 'GET',
        success: function (res) {
            $("#_cartDiv").html(res);
        },
        error: function (err) {
            console.log(err);
        }
    })
}
var pageSize = 10;
function getCatalog() {
    $("#catalog").hide(); 
    $("#_catalog").html('');
    $.ajax({
        url: '/Home/_Catalog',
        data: { dataSize: pageSize },
        type: 'GET',
        success: function (res) {
            $("#_catalog").html(res);
        },
        error: function (err) {
            console.log(err);
        }
    })
    pageSize = pageSize + 10;
}


function AddtoCart(x) {
    //SweetAlertDeleteConfirmation('warning', '', 'Are you sure, you want to Add this item to Cart?', '', 'Item added to Cart successfully.', '', 'Item not added to Cart', '/Shopping/AddProductToCart', x);
    
    var IsAdded = DeleteFunction('/Shopping/AddProductToCart', x);
    if (IsAdded) {
        swal({
            title: '',
            text: "Added to Cart",
            type: 'success'
        }, function () {
            getCart();
        });
    }
    else {
        swal("An error occured", "", "error");
    }
}

function RemoveCart(x) {
    
    var Isdeleted = DeleteFunction('/Shopping/RemoveCart', x);
    if (Isdeleted) {
        //swal({
        //    title: '',
        //    text: "Removed",
        //    type: 'success'
        //}, function () {
        //    location.reload();
        //});
        location.reload();
    }
    else {
        swal("An error occured", "", "error");
    }
}

