$(document).ready(function () {
  loadDVDs();
  addDVD();
  updateDVD();
  $("#searchDVDButton").click(function (event) {
        searchDVDs();
    })
});

//let root = "http://dvd-library.us-east-1.elasticbeanstalk.com";
let root = "https://localhost:44377"

//LOAD ALL DVDs
function loadDVDs() {
  clearDVDTable();
  var contentRows = $("#contentRows");

  $.ajax({
    type: "GET",
    url: root + "/dvds",
    success: function (dvdArray) {
      $("#errorMessages").empty();
      $.each(dvdArray, function (index, dvd) {
        var id = dvd.id;
        var title = dvd.title;
        var releaseYear = dvd.releaseYear;
        var director = dvd.director;
        var rating = dvd.rating;
        var notes = dvd.notes;

        var row = "<tr>";
        row += '<td><button type="button" class="btn btn-link" onclick="viewDVDForm(' + id + ')">' + title + '</td>';
        row += "<td>" + releaseYear + "</td>";
        row += "<td>" + director + "</td>";
        row += "<td>" + rating + "</td>";
        row += '<td><button type="button" class="btn btn-link" onclick="showEditForm(' + id + ')">Edit</button>' + ' | ' + '<button type="button" class="btn btn-link" onclick="deleteDVD(' + id + ')">Delete</button></td>';
        row += "</tr>";

        contentRows.append(row);
      });
      $("#clearResults").hide();
    },

    error: function () {
      $("#errorMessages").empty();
      $("#errorMessages").append(
        $("<li>")
        .attr({ class: "list-group-item list-group-item-danger" })
        .text("Error calling web service. Please try again later.")
      );
    },
  });
}

//LOAD SEARCH DVDs
function searchDVDs() {
  var form = document.getElementById("loadSearchResults");
  function handleForm(event) { event.preventDefault(); }
  form.addEventListener('submit', handleForm);

  clearDVDTable();
  var contentRows = $("#contentRows");
  const searchTerm = $("#searchTerm").val();
  const searchCategory = $("#searchCategory").val();

  if(searchCategory != null){
    $.ajax({
      type: "GET",
      url: root + "/dvds/" + searchCategory + "/" + searchTerm,
      success: function (dvdArray) {
        $.each(dvdArray, function (index, dvd) {
          var id = dvd.id;
          var title = dvd.title;
          var releaseYear = dvd.releaseYear;
          var director = dvd.director;
          var rating = dvd.rating;
          var notes = dvd.notes;

          var row = "<tr>";
          row += "<td>" + title + "</td>";
          row += "<td>" + releaseYear + "</td>";
          row += "<td>" + director + "</td>";
          row += "<td>" + rating + "</td>";
          row += '<td><button type="button" class="btn btn-link" onclick="showEditForm(' + id + ')">Edit</button>' + ' | ' + '<button type="button" class="btn btn-link" onclick="deleteDVD(' + id + ')">Delete</button></td>';
          row += "</tr>";

          contentRows.append(row);
        });
        $("#clearResults").show();
      },
    });
  }
  if(searchCategory == null || searchTerm == "")
  {
    loadDVDs();
  }
}

// CLEAR TABLE
function clearDVDTable() {
  $("#contentRows").empty();
}

// VIEW SINGLE DVD FORM
function viewDVDForm(id) {
  $("#errorMessages").empty();

  $.ajax({
    type: "GET",
    url: root + "/dvd/" + id,
    success: function (data, status) {
      $("#viewTitleHeader").html(data.title);
      $("#viewReleaseYear").val(data.releaseYear);
      $("#viewDirector").val(data.director);
      $("#viewRating").val(data.rating);
      $("#viewNotes").val(data.notes);
      $("#viewDVDId").val(data.id);
    },
    error: function () {
      $("#errorMessages").append(
        $("<li>")
        .attr({ class: "list-group-item list-group-item-danger" })
        .text("Error calling web service. Please try again later.")
      );
    },
  });

  $("#buttonDiv").hide();
  $("#DVDTableDiv").hide();
  $("#viewDVDForm").show();
}

// HIDE VIEW FORM
function hideViewForm() {
  $("#errorMessages").empty();

  $("#viewTitle").val("");
  $("#viewReleaseYear").val("");
  $("#viewDirector").val("");
  $("#viewRating").val("");
  $("#viewNotes").val("");

  $("#buttonDiv").show();
  $("#DVDTableDiv").show();
  $("#viewDVDForm").hide();
}

// ADD DVD
function addDVD() {
  $("#addButton").click(function (event) {
    var haveValidationErrors = checkAndDisplayValidationErrors(
      $("#addButton").find("input")
    );

    if (haveValidationErrors) {
      return false;
    }
    for (const el of document.getElementById('addForm')) {
      if (!el.reportValidity()) {
        return;
      }
    }

    $.ajax({
      type: "POST",
      url: root + "/dvd",
      data: JSON.stringify({
        title: $("#addTitle").val(),
        releaseYear: $("#addReleaseYear").val(),
        director: $("#addDirector").val(),
        rating: $("#addRating").val(),
        notes: $("#addNotes").val(),
      }),
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      dataType: "json",
      success: function () {
        $("#errorMessages").empty();
        $("#addTitle").val("");
        $("#addReleaseYear").val("");
        $("#addDirector").val("");
        $("#addRating").val("");
        $("#addNotes").val("");
        hideAddForm();
        loadDVDs();
      },
      error: function () {
        $("#errorMessages").append(
          $("<li>")
          .attr({ class: "list-group-item list-group-item-danger" })
          .text("Error calling web service. Please try again later.")
        );
      },
    });
  });
}

// SHOW ADD FORM
function showAddForm() {
  $("#buttonDiv").hide();
  $("#DVDTableDiv").hide();
  $("#addFormDiv").show();
}

// HIDE ADD FORM
function hideAddForm() {
  $("#errorMessages").empty();

  $("#addTitle").val("");
  $("#addReleaseYear").val("");
  $("#addDirector").val("");
  $("#addRating").val("");
  $("#addNotes").val("");

  $("#buttonDiv").show();
  $("#DVDTableDiv").show();
  $("#addFormDiv").hide();
}

// VIEW EDIT FORM
function showEditForm(id) {
  $("#errorMessages").empty();

  $.ajax({
    type: "GET",
    url: root + "/dvd/" + id,
    success: function (data, status) {
      $("#viewHeaderTitle").html("Edit DVD: " + data.title);
      $("#editTitle").val(data.title);
      $("#editReleaseYear").val(data.releaseYear);
      $("#editDirector").val(data.director);
      $("#editRating").val(data.rating);
      $("#editNotes").val(data.notes);
      $("#editDVDId").val(data.id);
    },
    error: function () {
      $("#errorMessages").append(
        $("<li>")
        .attr({ class: "list-group-item list-group-item-danger" })
        .text("Error calling web service. Please try again later.")
      );
    },
  });

  $("#buttonDiv").hide();
  $("#DVDTableDiv").hide();
  $("#editFormDiv").show();
}

// HIDE EDIT FORM
function hideEditForm() {
  $("#errorMessages").empty();

  $("#editTitle").val("");
  $("#editReleaseYear").val("");
  $("#editDirector").val("");
  $("#editRating").val("");
  $("#editNotes").val("");

  $("#buttonDiv").show();
  $("#DVDTableDiv").show();
  $("#editFormDiv").hide();
}

// UPDATE DVD
function updateDVD(id) {
  $("#updateButton").click(function (event) {
    var haveValidationErrors = checkAndDisplayValidationErrors(
      $("#addButton").find("input")
    );

    if (haveValidationErrors) {
      return false;
    }
    for (const el of document.getElementById('editForm')) {
      if (!el.reportValidity()) {
        return;
      }
    }

    $.ajax({
      type: "PUT",
      url: root + "/dvd/" + $("#editDVDId").val(),

      data: JSON.stringify({
        id: $("#editDVDId").val(),
        title: $("#editTitle").val(),
        releaseYear: $("#editReleaseYear").val(),
        director: $("#editDirector").val(),
        rating: $("#editRating").val(),
        notes: $("#editNotes").val(),
      }),
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      // dataType: "json",
      success: function () {
        $("#errorMessage").empty();
        hideEditForm();
        loadDVDs();
      },
      error: function () {
        $("#errorMessages").append(
          $("<li>")
          .attr({ class: "list-group-item list-group-item-danger" })
          .text("Error calling web service. Please try again later.")
        );
      },
    });
  });
}

// DELETE DVD
function deleteDVD(id) {
  if (confirm("Do you wish to delete this dvd?") == true) {
    $.ajax({
      type: "DELETE",
      url: root + "/dvd/" + id,
      success: function () {
        loadDVDs();
      },
    });
  }
}

// collect and display data validation error messages
function checkAndDisplayValidationErrors(input) {
  $("#errorMessages").empty();

  var errorMessages = [];

  // generate specific message using form label and browser-generated errors messages
  input.each(function () {
    if (!this.validity.valid) {
      var errorField = $("label[for=" + this.id + "]").text();
      errorMessages.push(errorField + " " + this.validationMessage);
    }
  });

  // display messages in #errorMessages div
  if (errorMessages.length > 0) {
    $.each(errorMessages, function (index, message) {
      $("#errorMessages").append(
        $("<li>")
        .attr({ class: "list-group-item list-group-item-danger" })
        .text(message)
      );
    });
    // return true, indicating that there were errors
    return true;
  } else {
    // return false, indicating that there were no errors
    return false;

  }
}
