$(document).ready(function(){
    "use strict"
	
	/*slideshow script code start here*/
	$('.slideshow').owlCarousel({
				loop: true,
				margin: 0,
				autoplay: true,
				smartSpeed: 1500,
				dots: false,
				nav:false,
				navText:['<i class="fa fa-long-arrow-left fa1"></i>', '<i class="fa fa-long-arrow-right fa2"></i>'],
				responsiveClass: true,
				responsive: {
					0: {
						items: 1
					},
					991: {
						items: 1
					},
					1180: {
						items: 1
					}
				}
			});
	/*slideshow script code end here*/
	
	/*#ad-single script code start here*/
			$('#ad-single').owlCarousel({
				loop: true,
				margin: 0,
				items: 1,
				autoplay: false,
				smartSpeed: 2500,
				dots: false,
				nav:true,
				navText:[['Back', 'Next']],
				responsiveClass: true,
				responsive: {
					0: {
						items: 1
					},
					768: {
						items: 1
					},
					991: {
						items: 1
					},
					1180: {
						items: 1
					}
				}
			});
	/*#ad-single script code end here*/
	
});