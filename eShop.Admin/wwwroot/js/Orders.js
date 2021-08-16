function getOrderDetails(orderId) {

    $.ajax({
        type: "GET",
        url: `/Order/GetDetails/`,
        data: { orderId: orderId },
        dataType: "html",
        success: function (data) {
            console.log('data:', data);
            document.getElementById('order-details').innerHTML = data;
        },
        error: function (err) {
            console.log('somthing went wrong:', e);
        }
    });

}