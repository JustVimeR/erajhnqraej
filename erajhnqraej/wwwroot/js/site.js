const uri = 'api/Cars';
let cars = [];

function getCars() {
    fetch(uri)
        .then(response => response.json())
        .then(data => displayCars(data))
        .catch(error => console.error('Unable to get cars.', error));
}

function addCar() {
    const addPriceTextbox = document.getElementById('add-price');
    const addYearTextbox = document.getElementById('add-year');
    const addFuelTextbox = document.getElementById('add-fuel');
    const addRunTextbox = document.getElementById('add-run');
    const addPointTextbox = document.getElementById('add-point');
    const addBrandTextbox = document.getElementById('add-brand');
    const addModelTextbox = document.getElementById('add-model'); 

    const car = {
        brand: addBrandTextbox.value.trim(),
        model: addModelTextbox.value.trim(),
        year: addYearTextbox.value.trim(),
        price: addPriceTextbox.value.trim(),
        run: addRunTextbox.value.trim(),
        fuel: addFuelTextbox.value.trim(),
        point: addPointTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(car)
    })
        .then(response => response.json())
        .then(() => {
            getCars();
            addBrandTextbox.value = '';
            addModelTextbox.value = '';
            addYearTextbox.value = '';
            addPriceTextbox.value = '';
            addRunTextbox.value = '';
            addFuelTextbox.value = '';
            addPointTextbox.value = '';
        })
        .catch(error => console.error('Unable to add cars.', error));
}


function deleteCars(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getCars())
        .catch(error => console.error('Unable to delete cars.', error));
}

function displayEditForm(id) {
    const car = cars.find(car => car.id === id);

    document.getElementById('edit-id').value = car.id;
    document.getElementById('edit-price').value = car.price;
    document.getElementById('edit-year').value = car.year;
    document.getElementById('edit-fuel').value = car.fuel;
    document.getElementById('edit-run').value = car.run;
    document.getElementById('edit-point').value = car.point;
    document.getElementById('edit-brand').value = car.brand;
    document.getElementById('edit-model').value = car.model;
    document.getElementById('editForm').style.display = 'block';
}

function updateCar() {
    const carId = document.getElementById('edit-id').value;
    const car = {
        id: parseInt(carId, 10),
        brand: document.getElementById('edit-brand').value.trim(),
        model: document.getElementById('edit-model').value.trim(),
        year: document.getElementById('edit-year').value.trim(),
        price: document.getElementById('edit-price').value.trim(),
        run: document.getElementById('edit-run').value.trim(),
        fuel: document.getElementById('edit-fuel').value.trim(),
        point: document.getElementById('edit-point').value.trim()
    };
    fetch(`${uri}/${carId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(car)
    })
        .then(() => getCars())
        .catch(error => console.error('Unable to update car.', error));

    closeInput();

    return false;
}


function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function displayCars(data) {
    const tBody = document.getElementById('cars');

    tBody.innerHTML = '';

    const button = document.createElement('button');

    data.forEach(car => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${car.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteCars(${car.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(car.brand);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeModel = document.createTextNode(car.model);
        td2.appendChild(textNodeModel);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });
    cars = data;
}

