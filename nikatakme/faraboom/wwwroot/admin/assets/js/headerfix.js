(function($) {
	'use strict';
	
	//headerfixed
	$(window).on("scroll", function(e){
		if ($(window).scrollTop() >= 76) {
			$('.horizontal-main').addClass('fixed-header');
			$('.horizontal-main').addClass('visible-title');
		}
		else {
			$('.horizontal-main').removeClass('fixed-header');
			$('.horizontal-main').removeClass('visible-title');
		}
    });
})(jQuery);