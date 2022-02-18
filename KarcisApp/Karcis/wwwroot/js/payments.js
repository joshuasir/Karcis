if($("#footer").offset().top < window.innerHeight - $("#footer").height()){
    $("#footer").css("position", "fixed");
    $("#footer").css("bottom", "0");
}
else{
    $("#footer").css("position", "flex");
}

$(".bookingDetail").on("click", function(){
    $("#bookingDetailPopUp").css("display", "flex");
});

$(".bookingCancelCancel").on("click", function(){
    $("#bookingDeclined").css("display", "flex");
})

$(".bookingCancelYes").on("click", function(){
    $("#bookingApproved").css("display", "flex");
})

function closeAll(){
    $("#bookingDetailPopUp").css("display", "none");
    $("#bookingDeclined").css("display", "none");
    $("#bookingApproved").css("display", "none");
}