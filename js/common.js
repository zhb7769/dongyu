// JavaScript Document

//window.onscroll = function () {
//}

jQuery(document).ready(function ($) {
    $(window).scroll(function () {
        var sl = -Math.max(document.body.scrollLeft, document.documentElement.scrollLeft);
        if ($(window).scrollTop() > 90) {
            $("#nav_fix").addClass("active");
            document.getElementById('nav_fix').style.left = sl + 'px';
        }
        else {
            $("#nav_fix").removeClass("active");
            document.getElementById('nav_fix').style.left = '0';
        }
    });
    if ($("#gotop").length > 0) {
        /* 下拉显示 */
        $(window).scroll(function () {
            if ($(window).scrollTop() > 150) {
                $("#gotop").fadeIn(1000);
            }
            else {
                $("#gotop").fadeOut(1000);
            }
        });
        //当点击跳转链接后，回到页面顶部位置
        $("#gotop").click(function () {
            $("#gotop").css('opacity', '1');
            $('body,html').animate({ scrollTop: 0 }, 1000);
            return false;
        });
    };
});
/*=====首页=====*/
// 首页图片轮播
$(function () {
    var sWidth = $("#focus").width(); //获取焦点图的宽度（显示面积）
    var len = $("#focus ul li").length; //获取焦点图个数
    var index = 0;
    var picTimer;

    //以下代码添加数字按钮和按钮后的半透明条，还有上一页、下一页两个按钮
    var btn = "<div class='btnBg'></div><div class='title'></div><div class='btn'>";

    for (var i = 0; i < len; i++) {
        btn += "<span></span>";
    }
    btn += "</div><div class='preNext pre'></div><div class='preNext next'></div>";
    $("#focus").append(btn);

    //为小按钮添加鼠标滑入事件，以显示相应的内容
    $("#focus .btn span").mouseover(function () {
        index = $("#focus .btn span").index(this);
        showPics(index);
    }).eq(0).trigger("mouseover");

    //本例为左右滚动，即所有li元素都是在同一排向左浮动，所以这里需要计算出外围ul元素的宽度
    $("#focus ul").css("width", sWidth * (len));

    //鼠标滑上焦点图时停止自动播放，滑出时开始自动播放
    $("#focus").hover(function () {
        clearInterval(picTimer);
    }, function () {
        picTimer = setInterval(function () {
            showPics(index);
            index++;
            if (index == len) { index = 0; }
        }, 6000); //此4000代表自动播放的间隔，单位：毫秒
    }).trigger("mouseleave");

    //显示图片函数，根据接收的index值显示相应的内容
    function showPics(index) { //普通切换
        var nowLeft = -index * sWidth; //根据index值计算ul元素的left值
        //$("#focus ul").stop(true,false).animate({"left":nowLeft},300); //通过animate()调整ul元素滚动到计算出的position
        $("#focus ul").stop(true, false).animate({ "left": nowLeft }, 650);
        $("#focus .title").text($("#focus ul li").eq(index).contents("a").contents("img").attr("alt"));
        $("#focus .btn span").stop(true, false).removeClass("on").eq(index).stop(true, false).addClass("on"); //为当前的按钮切换到选中的效果
    }
});

//菜单栏切换
//$(function () {
//    $("#ind_pro_tab a").hover(function () {
//        $(this).addClass('act').siblings().removeClass('act');
//        $('.ind_pro_tab_c').eq($(this).index()).show().siblings().hide();
//    });
//})

/*=====语言切换（中英文站互跳，保留当前页及参数）=====*/
// lang: 'en' 切换到英文站，'cn' 切换到中文站
function switchLang(lang) {
    var path = window.location.pathname;        // 如 /dongyu/Product.aspx 或 /dongyu/en/Product.aspx
    var search = window.location.search;        // 如 ?id=3
    var segs = path.split('/');                 // 按斜杠分段
    // 末段是文件名（如 Product.aspx），倒数第二段可能是 en 目录
    var fileName = segs[segs.length - 1];       // 可能为空（直接访问目录）
    var dirSeg = segs[segs.length - 2] || '';

    var isEn = (dirSeg.toLowerCase() === 'en'); // 当前是否在英文站
    var isDir = (fileName === '');              // 是否目录访问（末段无文件名）

    var newPath;
    if (lang === 'en') {
        // 跳英文站：当前已是英文则不动；否则插入 en/
        newPath = isEn ? path
                       : (isDir ? path + 'en/' : path.replace(/\/[^/]*$/, '/en/' + fileName));
    } else {
        // 跳中文站：当前是英文则去掉 en/；否则不动
        newPath = isEn ? (isDir ? path.replace(/\/en\/$/, '/') : path.replace(/\/en\/[^/]*$/, '/' + fileName))
                       : path;
    }
    window.location.href = newPath + search;
}