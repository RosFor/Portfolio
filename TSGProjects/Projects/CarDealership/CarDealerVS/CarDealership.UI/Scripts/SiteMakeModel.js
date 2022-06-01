$(document).ready(function () {
  $('#Make').change(function (){
    var MakeID = $(this).val();
    getMake(MakeID);
  });
  function getMake(ModelID){
    $select = $('#Model')
    $.ajax({
      type: "GET",
      url: 'http://localhost:44396/api/Admin/Models/' + ModelID,
      dataType: 'JSON',
      success:function(data) {
        $('#Model').empty();
        $.each(data, function(index, model) {
            $select.append('<option value="' + model.VehicleModelID + '">' + model.ModelName + '</option>');
        })
      },
      error: function(){
        alert('Please try again...');
      }});
    };
  });
