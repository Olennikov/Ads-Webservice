/// <reference path="C:\Users\Denis\Documents\Visual Studio 2015\Projects\RentService\RentService\Libs/jquery-1.11.3.min.js" />

function send(url, data, complete) {

    $.ajax({
        type: 'POST',
        url: url,
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        processdata: false,
        //implementing complete foo
        success: function (resp) {
            complete(resp);
            console.log(resp);
            console.log('succeded!!!');
        },
        error: function (resp) {
            console.log(resp);
            console.log('failed!!!');
        }
    });
};

// this method overloads existing REGEX for email validation
$.validator.methods.email = function (value, element) {
    return this.optional(element) || /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(value);
}

$(document).ready(function () {

    $('#searchBtn').on('click', function () {
        window.location.replace('http://localhost:50591/View/add_ad.html')
    })

    $('#signup-form').validate({
        submitHandler: function () {
            var user = {
                UserEmail: $('#signup-email').val(),
                UserPassword: $('#signup-password').val(),
            };
            console.log(JSON.stringify(user));

            send('http://localhost:50591/AdDataService.svc/post/newUser', user, function () {  //uses ajax to send data
                //alert("!!!");
            });
        },

        ignore: ".ignore",        // by defolt ":hidden" (need to change for validating hidden inputs!)
        rules: {
            signupEmail: {        //name="signinEmail" (field) as attr required for proper work!
                required: true,
                email: true       //email - email input
            },
            signupPass: {
                required: true,
                minlength: 2
            },
            confirm_password: {
                required: true,
                minlength: 2,
                equalTo: "#signup-password"
            },
            agree: "required"
        },

        messages: {
            signupEmail: {
                required: "Email is required",
                email: "Please enter a valid email address!"
            },
            signupPass: {
                required: "Please provide a password",
                minlength: "Your password must be at least 2 characters long"
            },
            confirm_password: {
                required: "Please provide a password",
                minlength: "Your password must be at least 2 characters long",
                equalTo: "Please enter the same password as above"
            },
            agree: "Please accept our policy"
        }
    });

    $('#signin-form').validate({

        submitHandler: function () {
            var user = {
                UserEmail: $('#signin-email').val(),
                UserPassword: $('#signin-password').val(),
            };
            console.log(JSON.stringify(user));

            send('http://localhost:50591/AdDataService.svc/validate', user, function (token) {  //uses ajax to send data
                //console.log(token.SessionToken);
                //alert("!!!");
                sessionStorage.setItem('userToken', token.SessionToken);  // Set Token to sessionStorage
                window.location.replace('http://localhost:50591/View/add_ad.html')
            });
        },

        ignore: ".ignore" ,
        rules: {
            signinEmail: {        //name="signinEmail" (field) as attr required for proper work!
                required: true,
                email: true       //email - email input
            },
            signinPass: {
                required: true,
                minlength: 2
            }
        },

        messages: {
            signinEmail: {
                required: "Email is required",
                email: "Please enter a valid email address!"
            },
            signinPass: {
                required: "Please provide a password",
                minlength: "Your password must be at least 2 characters long"
            }
        }
    });
});

function SaveRetriveDataOnReload(fieldId) {
    var field = document.getElementById(fieldId);

    // See if we have an autosave value
    // (this will only happen if the page is accidentally refreshed)
    if (sessionStorage.getItem("autosave")) {
        field.value = sessionStorage.getItem("autosave");
    }

    // Listen for changes in the text field
    field.addEventListener("change", function () {
        // And save the results into the session storage object
        sessionStorage.setItem("autosave", field.value);
    });
}