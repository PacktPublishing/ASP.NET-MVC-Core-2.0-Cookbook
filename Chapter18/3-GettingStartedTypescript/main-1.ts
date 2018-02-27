function logProductNameUsingPromises() {
    return fetch('./data/products.json')
           .then((response: any) => {
              return response.json();
           })
           .then((product: any) => {
             console.log(`${product.title} ${product.price}`);
           })
}

async function logProductNameUsingAsyncAwait() {
    let response = await fetch('./data/products.json');
    let product = await response.json();
    console.log(`${product.title} ${product.price}`);
}
