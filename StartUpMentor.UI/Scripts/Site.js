$(window).on('scroll', function () {
    if ($(window).scrollTop() > 100) {
        $('.navbar').removeClass('navbar-top');
    } else {
        $('.navbar').addClass('navbar-top');
    }

});