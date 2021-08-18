$('#deleteCategoryModal').on('show.bs.modal', function (event) {

    let button = $(event.relatedTarget)// Button that triggered the modal

    let id = button.data('id') // Extract info from data-* attributes

    $(this).find('.value').attr('value', id);

});

$('#categoryModal').on('show.bs.modal', function (event) {
    let button = $(event.relatedTarget)// Button that triggered the modal
    let id = button.data('id') // Extract info from data-* attributes

    let modal = $(this)

    if (id == null) {

        modal.find('.modal-title').text('კატეგორიის დამატება');
        $('#ID').val('');
        $('#Name').val('');
    }

    else {
        modal.find('.modal-title').text('კატეგორიის რედაქტირება');

        $.ajax({
            type: "GET",
            url: `/Category/GetCategory/`,
            data: { id: id },
            dataType: "json",
            success: function (data) {
                $('#ID').val(data.ID);
                $('#Name').val(data.Name);
            },
            error: function (err) {
                console.log('somthing went wrong:', err);
            }
        });
    }
});