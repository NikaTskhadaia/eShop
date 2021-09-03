
$('#deleteProductModal').on('show.bs.modal', function (event) {

    let button = $(event.relatedTarget)// Button that triggered the modal

    let id = button.data('id') // Extract info from data-* attributes

    $(this).find('.value').attr('value', id);

});

$('#productModal').on('show.bs.modal', function (event) {
    let button = $(event.relatedTarget)// Button that triggered the modal
    let id = button.data('id') // Extract info from data-* attributes

    let modal = $(this)

    if (id == null) {

        modal.find('.modal-title').text('პროდუქტის დამატება');
        $('#ID').val('');
        $('#Name').val('');
        $('#Unit').val('');
        $('#Description').val('');
        $('#Price').val('');
        $('#Quantity').val('');
    }

    else {
        modal.find('.modal-title').text('პროდუქტის რედაქტირება');

        $.ajax({
            type: "GET",
            url: `/Product/GetProduct/`,
            data: { id: id },
            dataType: "json",
            success: function (data) {
                $('#ID').val(data.ID);
                $('#Name').val(data.Name);
                $('#dropdownUnitButton').html(data.Unit);
                $('#Description').val(data.Description);
                $('#Price').val(data.Price);
                $('#Quantity').val(data.Quantity);
            },
            error: function (err) {
                console.log('somthing went wrong:', err);
            }
        });
    }
});

$('.unit-change').on('click', 'input', function () {
    let unit = $(this).val();
    console.log(unit);
    $('#dropdownUnitButton').html(unit);
});