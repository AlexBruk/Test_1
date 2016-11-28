function AddStoreKeeperSuccess(data) {
    if (data.success === false) {
        alertify.error(data.info);
    } else {
        alertify.success(data.info);
        setTimeout(function () {
            location.reload();
        }, 500);
    }
}


$('#AddStoreKeeper').click(function () {
    var url = '@Url.Action("AddStoreKeeper", "StoreKeeper")';
    $.ajax({
        url: url,
        success: function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        }
    });
});
$('.deleteSk').click(function () {
    var id = $(this).data("id");
    console.log(id);
    alertify.confirm("Вы действительно хотите удалить кладовщика?", function (e) {
        if (e) {
            var url = '@Url.Action("Delete","StoreKeeper")';
            $.ajax({
                url: url,
                data: { "id": id },
                method: "POST",
                success: function (data) {
                    if (data.success === false) {
                        alertify.error(data.info);
                    } else {
                        alertify.success(data.info);
                        setTimeout(function () {
                            location.reload();
                        }, 500);
                    }
                }
            });
        }
    });
});
