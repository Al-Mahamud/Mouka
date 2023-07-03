function myFunction() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " responsive";
    } else {
        x.className = "topnav";
    }
}

function loadscroler(){
		
}
$(document).ready(function(){
    "use strict"

	// Product Grid
	$('#grid-view').on('click',function(){
		
		$('.maincategory .row > .product-list').attr('class', 'product-layout product-grid col-lg-4 col-md-4 col-sm-6 col-xs-12 cols');
		localStorage.setItem('display', 'grid');
	});
	$('#list-view').on('click',function(){
		
		$('.maincategory .row > .product-grid').attr('class', 'product-layout product-list col-xs-12 cols');
		localStorage.setItem('display', 'list');
	});
	
	// Product Grid
	$('#grid-view').on('click',function(){
		
		$('.maincategory1 .row > .product-list').attr('class', 'product-layout product-grid col-lg-3 col-md-3 col-sm-4 col-xs-12 cols');
		localStorage.setItem('display', 'grid');
	});
	$('#list-view').on('click',function(){
		
		$('.maincategory1 .row > .product-grid').attr('class', 'product-layout product-list col-xs-12 cols');
		localStorage.setItem('display', 'list');
	});
	
	// collapse
	$('.btn-group').on('shown.bs.btn-group', function(){
	$(this).parent().removeClass("active").addClass("active");
	}).on('hidden.bs.btn-group', function(){
	$(this).parent().removeClass("active").addClass("");
	});
	
	// collapse
	$('.collapse').on('shown.bs.collapse', function(){
	$(this).parent().removeClass("active").addClass("active");
	$(this).parent().find(".fa-angle-right").removeClass("fa-angle-right").addClass("fa-angle-down");
	}).on('hidden.bs.collapse', function(){
	$(this).parent().find(".fa-angle-down").removeClass("fa-angle-down").addClass("fa-angle-right");
	$(this).parent().removeClass("active").addClass("");
	});
	
	
});