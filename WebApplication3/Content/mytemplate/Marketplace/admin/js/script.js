$(".toggle-password").click(function() {

  $(this).toggleClass("fa-eye fa-eye-slash");
  var input = $($(this).attr("toggle"));
  if (input.attr("type") == "password") {
    input.attr("type", "text");
  } else {
    input.attr("type", "password");
  }
});

function sticky_header() {
    var header_height = jQuery('.site-header').innerHeight() / 2;
    var scrollTop = jQuery(window).scrollTop();;
    if (scrollTop > header_height) {
        jQuery('body').addClass('sticky-header');
    } else {
        jQuery('body').removeClass('sticky-header');
    }
}

jQuery(document).ready(function () {
  sticky_header();
});

jQuery(window).scroll(function () {
  sticky_header();  
});
jQuery(window).resize(function () {
  sticky_header();
});

var el = document.querySelector('.more');
var btn = el.querySelector('.more-btn');
var menu = el.querySelector('.more-menu');
var visible = false;

function showMenu(e) {
    e.preventDefault();
    if (!visible) {
        visible = true;
        el.classList.add('show-more-menu');
        menu.setAttribute('aria-hidden', false);
        document.addEventListener('mousedown', hideMenu, false);
    }
}

function hideMenu(e) {
    if (btn.contains(e.target)) {
        return;
    }
    if (visible) {
        visible = false;
        el.classList.remove('show-more-menu');
        menu.setAttribute('aria-hidden', true);
        document.removeEventListener('mousedown', hideMenu);
    }
}

btn.addEventListener('click', showMenu, false);

