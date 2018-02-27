var App = {
    current: 0,
    increment: function(num) {
        this.current += num || 1;
    },
    decrement: function(num) {
        this.current -= num || 1;
    },
    isEven: function() {
        return this.current % 2 === 0;
    },
    isOdd: function() {
        return this.current % 2 !== 0;
    }
};
