window.bootstrapModalShow = (element) => {
    if (element) {
        const modal = new bootstrap.Modal(element);
        modal.show();
    }
};

window.bootstrapModalHide = (element) => {
    if (element) {
        const modal = bootstrap.Modal.getInstance(element);
        if (modal) {
            modal.hide();
        }
    }
};


window.makeModalDraggable = (id) => {
    $("#" + id).draggable({ handle: ".modal-header" });
};

window.makeModalResizable = (id) => {
    $("#" + id).resizable();
};