function DeleteUser(id) {
    if (confirm("Are you sure want to delete?")) {
        $.post('/User/DeleteUser', { id: id },
       function (htmlData) {
           var content = $('#bodyContent');
           content.empty();
           content.append(htmlData);
       });
    }
    return false;
}

function AddUser() {
    $.post('/User/AddUser',
             $(document.forms["frmAddUser"]).serialize(),
      function (htmlData) {
          var content = $('#bodyContent');
          content.empty();
          content.append(htmlData);
          location.reload();
      });
}

function EditUser(id) {
    $.post('/User/EditUser', { id: id },
    function (htmlData) {
        var content = $('#bodyContent');
        content.empty();
        content.append(htmlData);
        ///location.reload();
    });
}

function SearchUser() {
    $.post('/User/SearchUserByName', $(document.forms["frmUserList"]).serialize(),
    function (htmlData) {
        var content = $('#bodyContent');
        content.empty();
        content.append(htmlData);
    });
}