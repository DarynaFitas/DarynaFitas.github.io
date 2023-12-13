<html>
<body>
<h1 class="text-2xl font-bold mb-4">Список товарів</h1>

@if(session('success'))
    <div class="bg-green-200 text-green-800 p-4 mb-4">
        {{ session('success') }}
    </div>
@endif

@if($products->isEmpty())
    <p class="text-gray-600">Немає товарів.</p>
@else
    <ul class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
        @foreach($products as $product)
            <li class="border rounded p-4">
                {{ $product->name }} - {{ $product->manufacturer }} - {{ $product->price }}
                <form method="POST" action="{{ route('products.destroy', $product->id) }}">
                    @csrf
                    @method('DELETE')
                    <button type="submit">Вилучити</button>
                    <a href="{{ route('products.confirm-delete', $product->id) }}">Підтвердити вилучення</a>
                </form>
            </li>
        @endforeach
    </ul>
@endif
</body>
</html>
