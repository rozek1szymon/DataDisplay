$("#button").click(function () {
    var search = $("#isopen").val();
    $(".partial").load("/Home/Index2",
        { search });
});
