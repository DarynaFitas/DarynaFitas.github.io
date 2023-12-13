<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Manufacturer extends Model
{
    protected $fillable = ['brand', 'country', 'contact_phone', 'email'];

    public function products()
    {
        return $this->hasMany(Product::class);
    }
}

