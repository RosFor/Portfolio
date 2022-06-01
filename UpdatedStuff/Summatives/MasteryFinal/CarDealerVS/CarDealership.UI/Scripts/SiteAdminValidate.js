$(document).ready(function () {
  $("#Submit").click(
     function (e) {
             e.preventDefault();
         },
    function checkAndDisplayValidationErrors(input) {
      $("#errorMessages").empty();

      var errorMessages = [];

      input.each(function () {
        if (!this.validity.valid) {
          var errorField = $("label[for=" + this.id + "]").text();
          errorMessages.push(errorField + " " + this.validationMessage);
        }
      });

      if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
          $("#errorMessages").append(
            $("<li>")
            .attr({ class: "list-group-item list-group-item-danger" })
            .text(message)
          );
        });
        return true;
      } else {
        return false;
      }
    }
  );
});
