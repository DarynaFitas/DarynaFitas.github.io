<html>
<body>
<h1 class="text-2xl font-bold mb-4">Список товарів</h1>

<?php if(session('success')): ?>
    <div class="bg-green-200 text-green-800 p-4 mb-4">
        <?php echo e(session('success')); ?>

    </div>
<?php endif; ?>

<?php if($products->isEmpty()): ?>
    <p class="text-gray-600">Немає товарів.</p>
<?php else: ?>
    <ul class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
        <?php $__currentLoopData = $products; $__env->addLoop($__currentLoopData); foreach($__currentLoopData as $product): $__env->incrementLoopIndices(); $loop = $__env->getLastLoop(); ?>
            <li class="border rounded p-4">
                <?php echo e($product->name); ?> - <?php echo e($product->manufacturer); ?> - <?php echo e($product->price); ?>

                <form method="POST" action="<?php echo e(route('products.destroy', $product->id)); ?>">
                    <?php echo csrf_field(); ?>
                    <?php echo method_field('DELETE'); ?>
                    <button type="submit">Вилучити</button>
                    <a href="<?php echo e(route('products.confirm-delete', $product->id)); ?>">Підтвердити вилучення</a>
                </form>
            </li>
        <?php endforeach; $__env->popLoop(); $loop = $__env->getLastLoop(); ?>
    </ul>
<?php endif; ?>
</body>
</html>
<?php /**PATH /Applications/XAMPP/xamppfiles/htdocs/modul2php/modul2/resources/views/products/index.blade.php ENDPATH**/ ?>