
<html>
    <h1>Підтвердження вилучення товару</h1>

    <p>Ви впевнені, що хочете видалити товар "<?php echo e($product->name); ?>"?</p>

    <form method="POST" action="<?php echo e(route('products.destroy', $product->id)); ?>">
    <button type="submit">Так, видалити</button>
</form>

<a href="<?php echo e(route('products.index')); ?>">Скасувати</a>
</html>

<?php /**PATH /Applications/XAMPP/xamppfiles/htdocs/modul2php/modul2/resources/views/products/confirm-delete.blade.php ENDPATH**/ ?>