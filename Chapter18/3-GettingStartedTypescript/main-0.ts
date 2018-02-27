interface Customer {
    name: string;
    email: string;
    phone: string;
}

let customers: Array<Customer> = [];

customers.push({
    name: 'Engin Polat',
    email: 'engin@enginpolat.com',
    phone: '0123456789'
});

class Product {
    public title: string;
    public price: number;
    private updatedOn: Date;
}

let ledTV = new Product();
ledTV.title = 'Awesome LED TV with huge screen';
ledTV.price = 1000;
