function row(id, titre, image, prix, qte) {
    let newRow = document.createElement('tr');

    newRow.innerHTML = `
    <input type="hidden" class="hdi" name="id" value="${id}">
    <td class="text-center">
        <a><img style="height: 50px; " src="${image}" class="img-thumbnail" /></a>
    </td>
    <td class="text-left">
        <a>${titre}</a>
    </td>
    <td class="text-left">
        <div class="input-group btn-block quantity">
            <input type="number" min=1 value=${qte} name="quantity" onChange="updateQuantity(this, ${id}, ${prix})" class="form-control" />
        </div>
    </td>
    <td class="text-right">$ ${prix}</td>
    <td class="text-right">$ ${parseInt(prix) * parseInt(qte)}</td>
    `;
    return newRow;
}

function populateTable() {
    let products = localStorage.getItem('products');
    products = products ? JSON.parse(products) : [];

    products.forEach((item, index)=>{
        let _row = row(item.id, item.titre, item.image, item.prix, item.quantite);
        let body = document.getElementById('cart-list');
        if (body != undefined)
            body.appendChild(_row);
    })
    
}

function updateQuantity(input, id, prix) {
    prix = parseInt(prix);
    let products = localStorage.getItem('products');
    products = products ? JSON.parse(products) : [];

    let prixTotal = localStorage.getItem('prixTotal');
    prixTotal = prixTotal > 0 ? prixTotal : 0;

    let oldQuantity = 1;
    let newQuantity = parseInt(input.value);

    products.forEach((item, index)=>{
        if (item.id == id) {
            oldQuantity = item.quantite;
            item.quantite = newQuantity;
            return;
        }
    })

    if (newQuantity >= 1) {
        let quantityDifference = newQuantity - parseInt(oldQuantity);
        prixTotal = parseInt(prixTotal) + (quantityDifference * prix);
        localStorage.setItem('prixTotal', prixTotal);
        document.querySelector('.total-price-cart').innerHTML = prixTotal;
    }
    localStorage.setItem('products', JSON.stringify(products));
}

window.onload = function () {
    populateTable();
    let prixTotal = localStorage.getItem('prixTotal');
    prixTotal = prixTotal > 0 ? prixTotal : 0;
    document.querySelector('.total-price-cart').innerHTML = prixTotal;
}