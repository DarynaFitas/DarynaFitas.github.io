//3.Дано послідовність чисел, які згенеровано випадковим чином. Сформувати новий масив, з чисел, які є більшими за перший елемент.
console.log();
function filterArray(arr) 
    {
    const result = [];
  
    if (arr.length > 0) 
    {
      const firstElement = arr[0];
  
      for (let i = 0; i < arr.length; i++) 
      {
        if (arr[i] > firstElement) 
        {
          result.push(arr[i]);
        }
      }
    }
  
    return result;
    }
  