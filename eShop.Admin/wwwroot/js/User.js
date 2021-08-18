$('#deleteUserModal').on('show.bs.modal', function (event) {

    let button = $(event.relatedTarget)// Button that triggered the modal

    let id = button.data('id') // Extract info from data-* attributes

    $(this).find('.value').attr('value', id);

});

$('#userModal').on('show.bs.modal', function (event) {
    let button = $(event.relatedTarget)// Button that triggered the modal
    let id = button.data('id') // Extract info from data-* attributes

    let modal = $(this)

    if (id == null) {

        modal.find('.modal-title').text('მომხმარებლის დამატება');
        $('#Id').val('');
        $('#SessionId').val('');
        $('#ActivateCode').val('');
        $('#IsActive').val('');
        $('#Email').val('');
        $('#FirstName').val('');
        $('#LastName').val('');
        $('#DateCreated').val('');
        $('#DateChanged').val('');
    }

    else {
        modal.find('.modal-title').text('მომხმარებლის რედაქტირება');

        $.ajax({
            type: "GET",
            url: "/User/GetUser/",
            data: { id: id },
            dataType: "json",
            success: function (data) {
                $('#Id').val(data.Id);
                $('#SessionId').val(data.SessionId);
                $('#ActivateCode').val(data.ActivateCode);
                $('#IsActive').val(data.IsActive);
                $('#Email').val(data.Email);
                $('#FirstName').val(data.FirstName);
                $('#LastName').val(data.LastName);
                $('#DateCreated').val(data.DateCreated);
                $('#DateChanged').val(data.DateChanged);
            },
            error: function (err) {
                console.log('somthing went wrong:', err);
            }
        });
    }
});