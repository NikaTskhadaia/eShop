function addToCart(id) {
    let quantity = $('#inputQuantity').val();
    $.ajax({
        type: "POST",
        url: '/Product/AddToCart/',
        data: { id: id, productQuantity: quantity},
        dataType: "json",
        success: function (data) { },
        error: function (err) {
            console.log('somthing went wrong:', err);
        }
    });
}