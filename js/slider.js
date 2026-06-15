/**
 * slider插件可悬停控制
 */
 $(function ($, window, document, undefined) {
    Slider = function (container, options) {
        /*
        options = {
            auto: true,
            time: 3000,
            event: 'hover' | 'click',
            mode: 'slide | fade',
            controller: $(),
            activeControllerCls: 'className',
            exchangeEnd: $.noop
        }
        */

        "use strict"; //stirct mode not support by IE9-

        if (!container) return;

        var options = options || {},
            currentIndex = 0,
            cls = options.activeControllerCls,
            delay = options.delay,
            isAuto = options.auto,
            controller = options.controller,
            event = options.event,
            interval,
            slidesWrapper = container.children().first(),
            slides = slidesWrapper.children(),
            length = slides.length,
            childWidth = container.width(),
            totalWidth = childWidth * slides.length;

        function init() {
            var controlItem = controller.children();

            mode();

            event == 'hover' ? controlItem.mouseover(function () {
                stop();
                var index = $(this).index();

                play(index, options.mode);
            }).mouseout(function () {
                isAuto && autoPlay();
            }) : controlItem.click(function () {
                stop();
                var index = $(this).index();

                play(index, options.mode);
                isAuto && autoPlay();
            });

            isAuto && autoPlay();
        }

        //animate mode
        function mode() {
            var wrapper = container.children().first();

            options.mode == 'slide' ? wrapper.width(totalWidth) : wrapper.children().css({
                'position': 'absolute',
                'left': 0,
                'top': 0
            })
                .first().siblings().hide();
        }

        //auto play
        function autoPlay() {
            interval = setInterval(function () {
                triggerPlay(currentIndex);
            }, options.time);
        }

        //trigger play
        function triggerPlay(cIndex) {
            var index;

            (cIndex == length - 1) ? index = 0 : index = cIndex + 1;
            play(index, options.mode);
        }

        //play
        function play(index, mode) {
            slidesWrapper.stop(true, true);
            slides.stop(true, true);

            mode == 'slide' ? (function () {
                if (index > currentIndex) {
                    slidesWrapper.animate({
                        left: '-=' + Math.abs(index - currentIndex) * childWidth + 'px'
                    }, delay);
                } else if (index < currentIndex) {
                    slidesWrapper.animate({
                        left: '+=' + Math.abs(index - currentIndex) * childWidth + 'px'
                    }, delay);
                } else {
                    return;
                }
            })() : (function () {
                if (slidesWrapper.children(':visible').index() == index) return;
                slidesWrapper.children().fadeOut(delay).eq(index).fadeIn(delay);
            })();

            try {
                controller.children('.' + cls).removeClass(cls);
                controller.children().eq(index).addClass(cls);
            } catch (e) { }

            currentIndex = index;

            options.exchangeEnd && typeof options.exchangeEnd == 'function' && options.exchangeEnd.call(this, currentIndex);
        }

        //stop
        function stop() {
            clearInterval(interval);
        }

        //prev frame
        function prev() {
            stop();

            currentIndex == 0 ? triggerPlay(length - 2) : triggerPlay(currentIndex - 2);

            isAuto && autoPlay();
        }

        //next frame
        function next() {
            stop();

            currentIndex == length - 1 ? triggerPlay(-1) : triggerPlay(currentIndex);

            isAuto && autoPlay();
        }

        //init
        init();

        //expose the Slider API
        return {
            prev: function () {
                prev();
            },
            next: function () {
                next();
            }
        }
    };

}(jQuery, window, document));

//轮播切换
(function($, f) {
	var Unslider = function() {
		//  Object clone
		var _ = this;

		//  Set some options
		_.o = {
			speed: 500,     // animation speed, false for no transition (integer or boolean)
			delay: 3000,    // delay between slides, false for no autoplay (integer or boolean)
			init: 0,        // init delay, false for no delay (integer or boolean)
			pause: !f,      // pause on hover (boolean)
			loop: !f,       // infinitely looping (boolean)
			keys: f,        // keyboard shortcuts (boolean)
			dots: f,        // display dots pagination (boolean)
			arrows: f,      // display prev/next arrows (boolean)
			prev: '&larr;', // text or html inside prev button (string)
			next: '&rarr;', // same as for prev option
			fluid: f,       // is it a percentage width? (boolean)
			starting: f,    // invoke before animation (function with argument)
			complete: f,    // invoke after animation (function with argument)
			items: '>ul',   // slides container selector
			item: '>li',    // slidable items selector
			easing: 'swing',// easing function to use for animation
			autoplay: true  // enable autoplay on initialisation
		};

		_.init = function(el, o) {
			//  Check whether we're passing any options in to Unslider
			_.o = $.extend(_.o, o);

			_.el = el;
			_.ul = el.find(_.o.items);
			_.max = [el.outerWidth() | 0, el.outerHeight() | 0];
			_.li = _.ul.find(_.o.item).each(function(index) {
				var me = $(this),
					width = me.outerWidth(),
					height = me.outerHeight();

				//  Set the max values
				if (width > _.max[0]) _.max[0] = width;
				if (height > _.max[1]) _.max[1] = height;
			});


			//  Cached vars
			var o = _.o,
				ul = _.ul,
				li = _.li,
				len = li.length;

			//  Current indeed
			_.i = 0;

			//  Set the main element
			el.css({width: _.max[0], height: li.first().outerHeight(), overflow: 'hidden'});

			//  Set the relative widths
			ul.css({position: 'relative', left: 0, width: (len * 100) + '%'});
			if(o.fluid) {
				li.css({'float': 'left', width: (100 / len) + '%'});
			} else {
				li.css({'float': 'left', width: (_.max[0]) + 'px'});
			}

			//  Autoslide
			o.autoplay && setTimeout(function() {
				if (o.delay | 0) {
					_.play();

					if (o.pause) {
						el.on('mouseover mouseout', function(e) {
							_.stop();
							e.type == 'mouseout' && _.play();
						});
					};
				};
			}, o.init | 0);

			//  Keypresses
			if (o.keys) {
				$(document).keydown(function(e) {
					var key = e.which;

					if (key == 37)
						_.prev(); // Left
					else if (key == 39)
						_.next(); // Right
					else if (key == 27)
						_.stop(); // Esc
				});
			};

			//  Dot pagination
			o.dots && nav('dot');

			//  Arrows support
			o.arrows && nav('arrow');

			//  Patch for fluid-width sliders. Screw those guys.
			if (o.fluid) {
				$(window).resize(function() {
					_.r && clearTimeout(_.r);

					_.r = setTimeout(function() {
						var styl = {height: li.eq(_.i).outerHeight()},
							width = el.outerWidth();

						ul.css(styl);
						styl['width'] = Math.min(Math.round((width / el.parent().width()) * 100), 100) + '%';
						el.css(styl);
						li.css({ width: width + 'px' });
					}, 50);
				}).resize();
			};

			//  Move support
			if ($.event.special['move'] || $.Event('move')) {
				el.on('movestart', function(e) {
					if ((e.distX > e.distY && e.distX < -e.distY) || (e.distX < e.distY && e.distX > -e.distY)) {
						e.preventDefault();
					}else{
						el.data("left", _.ul.offset().left / el.width() * 100);
					}
				}).on('move', function(e) {
					var left = 100 * e.distX / el.width();
				        var leftDelta = 100 * e.deltaX / el.width();
					_.ul[0].style.left = parseInt(_.ul[0].style.left.replace("%", ""))+leftDelta+"%";

					_.ul.data("left", left);
				}).on('moveend', function(e) {
					var left = _.ul.data("left");
					if (Math.abs(left) > 30){

						var i = left > 0 ? _.i-1 : _.i+1;
						if (i < 0 || i >= len) i = _.i;
						_.to(i);
					}else{
						_.to(_.i);
					}
				});
			};

			return _;
		};

		//  Move Unslider to a slide index
		_.to = function(index, callback) {
			if (_.t) {
				_.stop();
				_.play();
	                }
			var o = _.o,
				el = _.el,
				ul = _.ul,
				li = _.li,
				current = _.i,
				target = li.eq(index);

			$.isFunction(o.starting) && !callback && o.starting(el, li.eq(current), index);

			//  To slide or not to slide
			if ((!target.length || index < 0) && o.loop == f) return;

			//  Check if it's out of bounds
			if (!target.length) index = 0;
			if (index < 0) index = li.length - 1;
			target = li.eq(index);

			var speed = callback ? 5 : o.speed | 0,
				easing = o.easing,
				obj = {height: target.outerHeight()};

			if (!ul.queue('fx').length) {
				//  Handle those pesky dots
				el.find('.dot').eq(index).addClass('active').siblings().removeClass('active');

				el.animate(obj, speed, easing) && ul.animate($.extend({left: '-' + index + '00%'}, obj), speed, easing, function(data) {
					_.i = index;

					$.isFunction(o.complete) && !callback && o.complete(index, el, target);
				});
			};
		};

		//  Autoplay functionality
		_.play = function() {
			_.t = setInterval(function() {
				_.to(_.i + 1);
			}, _.o.delay | 0);
		};

		//  Stop autoplay
		_.stop = function() {
			_.t = clearInterval(_.t);
			return _;
		};

		//  Move to previous/next slide
		_.next = function() {
			return _.stop().to(_.i + 1);
		};

		_.prev = function() {
			return _.stop().to(_.i - 1);
		};

		//  Create dots and arrows
		function nav(name, html) {
			if (name == 'dot') {
				html = '<ol class="dots">';
					$.each(_.li, function(index) {
						html += '<li class="' + (index == _.i ? name + ' active' : name) + '">' + ++index + '</li>';
					});
				html += '</ol>';
			} else {
				html = '<div class="';
				html = html + name + 's">' + html + name + ' prev">' + _.o.prev + '</div>' + html + name + ' next">' + _.o.next + '</div></div>';
			};

			_.el.addClass('has-' + name + 's').append(html).find('.' + name).click(function() {
				var me = $(this);
				me.hasClass('dot') ? _.stop().to(me.index()) : me.hasClass('prev') ? _.prev() : _.next();
			});
		};
	};

	//  Create a jQuery plugin
	$.fn.unslider = function(o) {
		var len = this.length;

		//  Enable multiple-slider support
		return this.each(function(index) {
			//  Cache a copy of $(this), so it
			var me = $(this),
				key = 'unslider' + (len > 1 ? '-' + ++index : ''),
				instance = (new Unslider).init(me, o);

			//  Invoke an Unslider instance
			me.data(key, instance).data('key', key);
		});
	};

	Unslider.version = "1.0.0";
})(jQuery, false);

//图片轮播
	var Speed = 10; //速度(毫秒)
	var Space = 20; //每次移动(px)
	var PageWidth = 210 * 4; //翻页宽度
	var interval = 3000; //翻页间隔时间
	var fill = 0; //整体移位
	var MoveLock = false;
	var MoveTimeObj;
	var MoveWay="right";
	var Comp = 0;
	var AutoPlayObj=null;
	function GetObj(objName){
		if(document.getElementById){
			return eval('document.getElementById("'+objName+'")')
		}else{return eval('document.all.'+objName)}
	}
	function AutoPlay(){
		clearInterval(AutoPlayObj);
		AutoPlayObj=setInterval('GoDown();StopDown();',interval)
	}
	function GoUp(){
		if(MoveLock)return;
		clearInterval(AutoPlayObj);
		MoveLock=true;MoveWay="left";
		MoveTimeObj=setInterval('ScrUp();',Speed);
	}
	function StopUp(){
		if(MoveWay == "right"){return};
		clearInterval(MoveTimeObj);
		if((GetObj('Cont').scrollLeft-fill)%PageWidth!=0){Comp=fill-(GetObj('Cont').scrollLeft%PageWidth);
		CompScr()}else{MoveLock=false}
		AutoPlay()}
	function ScrUp(){
		if(GetObj('Cont').scrollLeft<=0){GetObj('Cont').scrollLeft=GetObj('Cont').scrollLeft+GetObj('List1').offsetWidth}
GetObj('Cont').scrollLeft-=Space}
	function GoDown(){
		clearInterval(MoveTimeObj);
		if(MoveLock)return;
		clearInterval(AutoPlayObj);
		MoveLock=true;
		MoveWay="right";
		ScrDown();
		MoveTimeObj=setInterval('ScrDown()',Speed)
	}
	function StopDown(){
		if(MoveWay == "left"){return};
		clearInterval(MoveTimeObj);
		if(GetObj('Cont').scrollLeft%PageWidth-(fill>=0?fill:fill+1)!=0){Comp=PageWidth-GetObj('Cont').scrollLeft%PageWidth+fill;CompScr()}
		else{MoveLock=false}
		AutoPlay()}
	function ScrDown(){
		if(GetObj('Cont').scrollLeft>=GetObj('List1').scrollWidth){GetObj('Cont').scrollLeft=GetObj('Cont').scrollLeft-GetObj('List1').scrollWidth}
GetObj('Cont').scrollLeft+=Space}
	function CompScr(){
		if(Comp==0){MoveLock=false;return}
		var num,TempSpeed=Speed,TempSpace=Space;if(Math.abs(Comp)<PageWidth/2){TempSpace=Math.round(Math.abs(Comp/Space));if(TempSpace<1){TempSpace=1}}
		if(Comp<0){
			if(Comp<-TempSpace){Comp+=TempSpace;num=TempSpace}else{num=-Comp;Comp=0}
GetObj('Cont').scrollLeft-=num;setTimeout('CompScr()',TempSpeed)}else{if(Comp>TempSpace){Comp-=TempSpace;num=TempSpace}else{num=Comp;Comp=0}
GetObj('Cont').scrollLeft+=num;setTimeout('CompScr()',TempSpeed)}}
	function picrun_ini(){
GetObj("List2").innerHTML=GetObj("List1").innerHTML;
GetObj('Cont').scrollLeft=fill>=0?fill:GetObj('List1').scrollWidth-Math.abs(fill);
GetObj("Cont").onmouseover=function(){clearInterval(AutoPlayObj)}
GetObj("Cont").onmouseout=function(){AutoPlay()}
AutoPlay();
	}