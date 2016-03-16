/// <reference path="C:\Users\Denis\Documents\Visual Studio 2015\Projects\RentService\RentService\Lib/jquery-1.11.3.min.js" />

$(document).ready(function () {

    var token = sessionStorage.getItem('userToken');

    $.getJSON('http://localhost:50591/AdDataService.svc/check/' + token, function (responce) { 

        console.log(responce);
        if (responce == false) {
            sessionStorage.removeItem('userToken')
            window.location.replace("http://localhost:50591/View/main.html");
        }
        else {
            alert(11);
        }

    });

    ListingAnimation()

})

function ListingAnimation() {
    var basicVar = $('#basicPill'),
        descVar = $('#descPill'),
        rentVar = $('#rentPill');
        reachVar = $('#reachPill'),

    basicVar.on('click', function () {
        basicVar.addClass("active");
        descVar.removeClass("active");
        rentVar.removeClass("active");
        reachVar.removeClass("active");

        $('#basicInfo').show(500);
        $('#descInfo').hide();
        $('#rentInfo').hide();
        $('#reachInfo').hide();
    });
    descVar.on('click', function () {
        basicVar.removeClass("active");
        descVar.addClass("active");
        rentVar.removeClass("active");
        reachVar.removeClass("active");

        $('#basicInfo').hide();
        $('#descInfo').show(500);
        $('#rentInfo').hide();
        $('#reachInfo').hide();
    });
    rentVar.on('click', function () {
        basicVar.removeClass("active");
        descVar.removeClass("active");
        rentVar.addClass("active");
        reachVar.removeClass("active");

        $('#basicInfo').hide();
        $('#descInfo').hide();
        $('#rentInfo').show(500);
        $('#reachInfo').hide();
    });
    reachVar.on('click', function () {
        basicVar.removeClass("active");
        descVar.removeClass("active");
        rentVar.removeClass("active");
        reachVar.addClass("active");

        $('#basicInfo').hide();
        $('#descInfo').hide();
        $('#rentInfo').hide();
        $('#reachInfo').show(200);
    });


    $('#basicNext').on('click', function () {
        basicVar.removeClass("active");
        descVar.addClass("active");
        rentVar.removeClass("active");
        reachVar.removeClass("active");

        $('#basicInfo').hide();
        $('#descInfo').show(500);
        $('#rentInfo').hide();
        $('#reachInfo').hide();
    });

    $('#descNext').on('click', function () {
        basicVar.removeClass("active");
        descVar.removeClass("active");
        rentVar.addClass("active");
        reachVar.removeClass("active");

        $('#basicInfo').hide();
        $('#descInfo').hide();
        $('#rentInfo').show(500);
        $('#reachInfo').hide();
    });

    $('#rentNext').on('click', function () {
        basicVar.removeClass("active");
        descVar.removeClass("active");
        rentVar.removeClass("active");
        reachVar.addClass("active");

        $('#basicInfo').hide();
        $('#descInfo').hide();
        $('#rentInfo').hide();
        $('#reachInfo').show(200);
    })
}

