
<html>
    <h1>Підтвердження вилучення товару</h1>

    <p>Ви впевнені, що хочете видалити товар "{{ $product->name }}"?</p>

    <form method="POST" action="{{ route('products.destroy', $product->id) }}">
    <button type="submit">Так, видалити</button>
</form>

<a href="{{ route('products.index') }}">Скасувати</a>
</html>

