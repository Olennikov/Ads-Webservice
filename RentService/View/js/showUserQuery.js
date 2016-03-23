/// <reference path="C:\Users\Denis\Documents\Visual Studio 2015\Projects\RentService\RentService\Libs/jquery-1.11.3.min.js" />
'use strict';


//provide values from server to dinamicly add ads. TO DO: item_Price, ava_Src, img_Src
function CreateUserAd(item_price, item_name, item_city, item_desc) {
    var row = $('.ad_row'),
        divCol = $('<div></div>').addClass('col-sm-6 col-md-3').attr('id', 'res'),
        divImgWrap = $('<div></div>').addClass('img_wrap'),
        spanPrice = $('<span></span>').addClass('label label-danger price_lbl'),
        imgAva = $('<img/>').addClass('img-circle ava_img').attr({ src: "img/my_ava_80_80.png", width: "80", height: "80", alt: "user's avatar" }),
        imgItem = $('<img/>').addClass('img-responsive').attr({ src: "img/fox.png", width: "320", height: "249", alt: "item picture" }),
        divCaption = $('<div></div>').addClass('caption'),
        itemName = $('<p></p>').addClass('itemName'),
        pSpan = $('<p></p>').addClass('p_Span'),
        spanCity = $('<span></span>').addClass('label label-default'),
        pItemDesc = $('<p></p>').addClass('itemDesc'),
        pButton = $('<p></p>').addClass('p_Button'),
        aHrefBtn = $('<a></a>').addClass('btn btn-xs btn-primary').attr({ href: "#", role: "button" });

    row.append(divCol);
    divCol.append(divImgWrap, divCaption);
    divImgWrap.append(spanPrice.text('$' + item_price), imgAva, imgItem);
    pSpan.append(spanCity.text(item_city));
    pButton.append(aHrefBtn.text('More >>'));
    divCaption.append(itemName.text(item_name), pSpan, pItemDesc.text(item_desc), pButton);

}

function Clean_Previous_Search_Results(){
    var row = $('.ad_row');
    row.empty();
};
//CreateUserAd()
var url = 'http://localhost:50591/AdDataService.svc/';

function RecieveData() {
    Clean_Previous_Search_Results();
    var userQuery = $('#userSearchInput').val(),
        sendUserQueryUrl = url + 'search?query=' + userQuery,
        city = '',
        price = '',
        name = '',
        desc = '';

    $.getJSON(sendUserQueryUrl, function (responce) {

        for (var j = 0, k = responce.length; j < k; j++) {

            var obj = responce[j];

            $.each(obj, function (key, value) {
                if (key == 'City') city = value;
                else if (key == 'DailyRentPrice') price = value;
                else if (key == 'ItemName') name = value;
                else if (key == 'ItemDesc') desc = value;
            });
            CreateUserAd(price, name, city, desc);
        }

    });
}

$(document).ready(function () {

    $('#searchBtn').on('click', RecieveData);

});