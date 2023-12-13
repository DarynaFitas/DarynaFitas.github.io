
<?php $__env->startSection('content'); ?>
    <h1>Список товарів</h1>

    <?php if(session('success')): ?>
        <div class="alert alert-success">
            <?php echo e(session('success')); ?>

        </div>
    <?php endif; ?>

    <?php if($products->isEmpty()): ?>
        <p>Немає товарів.</p>
    <?php else: ?>
        <ul>
            <?php $__currentLoopData = $products; $__env->addLoop($__currentLoopData); foreach($__currentLoopData as $product): $__env->incrementLoopIndices(); $loop = $__env->getLastLoop(); ?>
                <li>
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
<?php $__env->stopSection(); ?>

<?php /**PATH /Applications/XAMPP/xamppfiles/htdocs/modul2php/modul2/resources/views/index.blade.php ENDPATH**/ ?>