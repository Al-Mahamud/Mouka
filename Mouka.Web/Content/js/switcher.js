$(document).ready(function(){
    "use strict"
	
	$(function () {
		"use strict";
		$('.styleswitch').on('click',function()
		{
			switchStylestyle(this.getAttribute("rel"));
			return false;
		});
		var c = readCookie('style');
		if (c) switchStylestyle(c);
	});

	function switchStylestyle(styleName)
	{
		$('link[rel*=style][title]').each(function(i) 
		{
			this.disabled = true;
			if (this.getAttribute('title') == styleName) this.disabled = false;
		});
		$('.logochange').attr('src','images/'+styleName+'.png');
        $('.bannerchange').attr('src','images/banner/'+styleName+'.jpg');
		createCookie('style', styleName, 365);
		$('.sliderchange').attr('src','images/slider/'+styleName+'.jpg');
		createCookie('style', styleName, 365);
	}
	
	$(function () {
		"use strict";
		$('.default-switch').on('click',function()
		{
			mainswitcherstyle(this.getAttribute("rel"));
			return false;
		});
		var c = readCookie('style');
		if (c) mainswitcherstyle(c);
	});

	function mainswitcherstyle(styleName)
	{
		$('link[rel*=style][title]').each(function(i) 
		{
			this.disabled = true;
			if (this.getAttribute('title') == styleName) this.disabled = false;
		});
		$('.logochange').attr('src','images/'+styleName+'.png');
	}
	
});
// cookie functions http://www.quirksmode.org/js/cookies.html
function createCookie(name,value,days) {
  if (days) {
    var date = new Date();
    date.setTime(date.getTime()+(days*24*60*60*1000));
    var expires = "; expires="+date.toGMTString();
  }
  else expires = "";
  document.cookie = name+"="+value+expires+"; path=/";
}
function readCookie(name) {
  var nameEQ = name + "=";
  var ca = document.cookie.split(';');
  for(var i=0;i < ca.length;i++) {
    var c = ca[i];
    while (c.charAt(0)==' ') c = c.substring(1,c.length);
    if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
  }
  return null;
}
function eraseCookie(name)
{
	createCookie(name,"",-1);
}

$('body').append('<div class="color-setting"><span class="icon"><i style="padding:8px;height:35px;width:35px;background:#000;cursor:pointer;color:#fff;position:fixed;top:25%;bottom:0;left:0%;font-size:18px;z-index:999999;" class="fa fa-cogs" aria-hidden="true"></i></span><div class="mainbox"><span><i style="padding:3px 5px 4px;height:25px;width:25px;background:#000;color:#fff;position:absolute;top:0%;bottom:0;left:100%;font-size:18px;cursor:pointer;" class="fa fa-times" aria-hidden="true"></i></span><ul class="list-inline"><li style="margin-bottom:10px;"><a href="javascript:;" rel="style" class="styleswitch"><span style="display: -moz-inline-stack;display: inline-block;*display: inline;width:20px;height:20px;padding:1px 10px;background:#FED700;border:1px solid #fff;"></span></a></li><li style="margin-bottom:10px;"><a href="javascript:;" rel="style_blue" class="styleswitch"><span style="display: -moz-inline-stack;display: inline-block;*display: inline;width:20px;height:20px;padding:1px 10px;background:#1DA1F3;border:1px solid #fff;"></span></a></li><li style="margin-bottom:10px;"><a href="javascript:;" rel="style_orange" class="styleswitch"><span style="display: -moz-inline-stack;display: inline-block;*display: inline;width:20px;height:20px;padding:1px 10px;background:#FB8A2E;border:1px solid #fff;"></span></a></li></ul></div></div><div class="mainswitcher"><div class="primary-switch"><input type="checkbox" id="default-switch" rel="style_black"><label for="default-switch" data-on="Dark Off" data-off="Dark Mode"></label></div></div>');

$('.color-setting .mainbox').hide();
$('.color-setting .icon .fa').on('click', function(){
    $('.color-setting .mainbox').show();
	$('.color-setting .mainbox').addClass('open');
    $('.color-setting .icon .fa').hide();
});
$('.color-setting .fa-times').on('click', function(){
    $('.color-setting .mainbox').hide();
    $('.color-setting .icon .fa').show();
	$('.color-setting .mainbox').removeClass('open');
});

$('#default-switch').on('click',function(){
	$(this).toggleClass('active');
	$('body').toggleClass('bg');
});

// /cookie functions