<?php

namespace App\Http\Controllers;

use App\Models\Product;
use Illuminate\Http\Request;

class ProductController extends Controller
{
    public function index()
    {

        $products = new Product();

        return view('products.index', ['products' => $products->all()]);
    }

    public function confirmDelete($id)
    {
        $product = Product::findOrFail($id);
        return view('products.confirm-delete', compact('product'));
    }

    public function destroy($id)
    {
        $product = Product::findOrFail($id);
        $product->delete();

        return redirect()->route('products.index')->with('success', 'Product deleted successfully.');
    }
}

