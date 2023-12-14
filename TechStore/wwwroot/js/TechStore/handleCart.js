function row(id, titre, image, prix) {
    let newRow = document.createElement('tr');

    newRow.innerHTML = `
            <td class="text-center">
                <input type="hidden" class="hdi" name="id" value="${id}">
                <span>
                    <img style="width: 50px;" class="img-thumbnail" src="${image}">
                </span>
            </td>
            <td class="text-left">
                <a>${titre}</a>
            </td>
            
            <td class="text-right">$${prix}</td>
            <td class="text-center">
                <button class="btn btn-danger btn-xs remove" title="Remove" onClick="removeFromCart(this, ${prix})" type="button">
                    <i class="fa fa-times"></i>
                </button>
            </td>
    `;
    return newRow
}

function productExist(array, id) {
    return array.some(element => element.id == id);
}

function addToCart(id, titre, image, prix) {
    var products = localStorage.getItem('products');
    products = products ? JSON.parse(products) : [];

    var prixTotal = localStorage.getItem('prixTotal');
    prixTotal = prixTotal ? parseInt(prixTotal) : 0;

    let product = {
        "id": id,
        "titre": titre,
        "image": image,
        "prix": prix,
    }

    if (products != undefined && products.length > 0) {
        if (!productExist(products, id)) {
            products.push(product);
            prixTotal += parseInt(prix);
            localStorage.setItem('products', JSON.stringify(products));
            document.getElementById('table-cart-list').appendChild(row(id, titre, image, prix));
        }

    } else {
        products.push(product);
        prixTotal += parseInt(prix);
        localStorage.setItem('products', JSON.stringify(products));
        document.getElementById('table-cart-list').appendChild(row(id, titre, image, prix));
    }


    localStorage.setItem('productsCount', products.length)
    document.getElementById('cart-total').innerText = products.length;


    document.querySelector('.total').innerText = prixTotal;
    localStorage.setItem('prixTotal', prixTotal)
}

function removeFromCart(button, prix) {
    let tbody = document.getElementById('table-cart-list');
    let grandparent = button.parentElement.parentElement;
    let id = grandparent.querySelector('.hdi').value;
    tbody.removeChild(grandparent);

    let products = localStorage.getItem('products');
    products = products ? JSON.parse(products) : [];

    let prixTotal = localStorage.getItem('prixTotal');
    prixTotal = prixTotal ? parseInt(prixTotal) : 0;

    if (products != undefined && products.length > 0) {
        products = products.filter(element => { return element.id != id; })
        prixTotal -= parseInt(prix);
        localStorage.setItem('prixTotal', prixTotal)
        localStorage.setItem('productsCount', products.length);
        localStorage.setItem('products', JSON.stringify(products));
        document.querySelector('.total').innerText = prixTotal;
        document.getElementById('cart-total').innerText = products.length;
    }
}

window.onload = function () {
    var prixTotal = localStorage.getItem('prixTotal');
    prixTotal = prixTotal ? parseInt(prixTotal) : 0;

    document.querySelector('.total').innerText = localStorage.getItem('prixTotal') ? parseInt(localStorage.getItem('prixTotal')) : 0;
    document.getElementById('cart-total').innerText = localStorage.getItem('productsCount') ? parseInt(localStorage.getItem('productsCount')) : 0;

    var products = localStorage.getItem('products');
    products = products ? JSON.parse(products) : [];

    if (products.length > 0) {
        products.forEach(element => {
            document.getElementById('table-cart-list').appendChild(row(element.id, element.titre, element.image, element.prix));
        });
    }
}