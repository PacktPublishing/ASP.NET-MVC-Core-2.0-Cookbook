QUnit.test('This is most basic test', function (assert) {
    assert.expect(1);
    assert.ok(true);
});

QUnit.test('This is another basic test', function (assert) {
    assert.ok(true, 'It works!');
});

QUnit.test('current number is zero', function (assert) {
    assert.equal(App.current, 0);
});

QUnit.test('current number is one after increment', function (assert) {
    App.increment();
    assert.equal(App.current, 1);
});

QUnit.test('current number is zero again after decrement', function (assert) {
    App.decrement();
    assert.equal(App.current, 0);
});

QUnit.test('current number is zero AND even', function (assert) {
    assert.equal(App.current, 0);
    assert.equal(App.isEven(), true);
});

QUnit.test('current number is odd after increment by 5', function (assert) {
    App.increment(5);
    assert.equal(App.isOdd(), true);
});
