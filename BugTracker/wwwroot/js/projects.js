window.onload = () =>{
    subscribeToEvents();
};

function subscribeToEvents() {
    const addNewBtn = document.querySelector('.create-btn');
    addNewBtn.addEventListener('click', manageForm);

    const menus = document.getElementsByClassName('menu');
    for (var i = 0; i < menus.length; i++) {
        var menuElement = menus[i];
        menuElement.addEventListener('click', manageMenu);
	}
}

function manageForm() {
    const formContainer = document.querySelector('#form-container');
    const classes = formContainer.classList;
    if (classes.contains('hidden')) {
        formContainer.classList.add('show');
        formContainer.classList.remove('hidden');
    }
    else {
        formContainer.classList.add('hidden');
        formContainer.classList.remove('show');
    }
}

function manageMenu(e) {
    let id = e.srcElement.id;
    const menuContainer = document.querySelector(`#menu-${id}`);
    const classes = menuContainer.classList;
    if (classes.contains('hidden')) {
        menuContainer.classList.add('show');
        menuContainer.classList.remove('hidden');
    }
    else {
        menuContainer.classList.add('hidden');
        menuContainer.classList.remove('show');
    }
}

