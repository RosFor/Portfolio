$(document).ready(function () {
    function notFeatured() {
        document.getElementById("#Model.Vehicle.IsFeatured").value = false;
    }
    $('#Make').change(function () {
        var MakeID = $(this).val();
        getMake(MakeID);
    });
    function getMake(ModelID) {
        $select = $('#Model')
        $.ajax({
            type: "GET",
            url: 'http://localhost:44396/api/Admin/Models/' + ModelID,
            dataType: 'JSON',
            success: function (data) {
                $('#Model').empty();
                $.each(data, function (index, model) {
                    $select.append('<option value="' + model.VehicleModelID + '">' + model.ModelName + '</option>');
                })
            },
            error: function () {
                alert('Please try again...');
            }
        });
    };
    /*function DeleteVehicle(id) {
        var id = model.Vehicle.VehicleID
        $.ajax({
            type: 'POST',
            url: 'http://http://localhost:44396/Admin/EditVehicle/' + id,
            success: function () {
                alert('Success');
            }
        });
    };*/
});
