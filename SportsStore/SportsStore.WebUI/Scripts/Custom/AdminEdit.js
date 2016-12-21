function selectView(view) {
    $('.display').not('#' + view + "Display").hide();
    $('#' + view + "Display").show();
}
function getData() {
    $.ajax({
        type: "GET",
        url: "/api/adminapi/",
        
        success: function (data) {
            $('#tableBody').empty();
            for (var i = 0; i < data.length; i++) {
                $('#tableBody').append('<tr><td><input id="id" name="id" type="radio"'
                + 'value="' + data[i].Id + '" /></td>'
                + '<td>' + data[i].Name + '</td>'
                + '<td>' + data[i].Description + '</td></tr>');
            }
            $('input:radio')[0].checked = "checked";
            selectView("summary");
        },
        error: function () {
            alert("error in get all");
        }
    });
}
$(document).ready(function () {
    selectView("summary");
    getData();
    $("button").click(function (e) {
        var selectedRadio = $('input:radio:checked')
        switch (e.target.id) {
            case "refresh":
                getData();
                break;
            case "delete":
                $.ajax({
                    type: "DELETE",
                    url: "/api/adminapi/" + selectedRadio.attr('value'),

                    success: function (data) {
                        selectedRadio.closest('tr').remove();
                    },
                    error: function () {
                        alert("error in http delete");
                    }
                });
                break;
            case "add":
                selectView("add");
                break;
            case "edit":
                $.ajax({
                    type: "GET",
                    url: "/api/adminapi/" + selectedRadio.attr('value'),
                    success: function (data) {
                        $('#editProductId').val(data.ProductId);
                        $('#editName').val(data.Name);
                        $('#editLocation').val(data.Description);
                        selectView("edit");
                    },
                    error: function () {
                        alert("error in get (id ) http")
                    }
                });
                break;
            case "submitEdit":
                $.ajax({
                    type: "PUT",
                    url: "/api/adminapi/" + selectedRadio.attr('value'),
                    data: $('#editForm').serialize(),
                    success: function (result) {
                        if (result) {
                            var cells = selectedRadio.closest('tr').children();
                            cells[1].innerText = $('#editName').val();
                            cells[2].innerText = $('#editLocation').val();
                            selectView("summary");
                        }
                    },
                    error: function () {
                        alert("error in put request");
                    }

                });
                break;
        }
    });
});