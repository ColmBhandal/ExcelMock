using CsharpExtras._Enumerable.OneBased;
using CsharpExtras.Extensions;
using ExcelMock._base;
using ExcelMock.mock.interop.worksheet.partial;
using ExcelMock.mock.interop.worksheet.partial.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.mock.interop.range.partial
{
    internal class PartialSheetAreaImpl : BaseClass, IPartialSheetArea
    {
        private int _startRow;
        private int _startCol;
        private int _endRow;
        private int _endCol;

        private readonly IPartialSheet _parent;

        public PartialSheetAreaImpl(int startRow, int startCol,
            int endRow, int endCol, IPartialSheet parent)
        {
            _startRow = startRow;
            _startCol = startCol;
            _endRow = endRow;
            _endCol = endCol;
            _parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }

        public IOneBasedArray2D<string> Formulas
        {
            get => GetCellDataArray().Map(c => c.Formula);
            set => UpdateCellData(value, (c, f) => c.Formula = f, "");
        }

        public IOneBasedArray2D<string> Values
        {
            get => GetCellDataArray().Map(c => c.Value);
            set => UpdateCellData(value, (c, v) => c.Value = v, "");
        }

        private void UpdateCellData<T>(IOneBasedArray2D<T> dataToSet, Action<ICellData, T> updater,
            T empty)
        {
            ValidateSize(dataToSet);
            IOneBasedArray2D<ICellData> cellDataArray = GetCellDataArray();
            ICellData updaterFunc(ICellData data, T t)
            {
                if(Equals(t, empty))
                {
                    if (!data.IsMutable)
                    {
                        return data;
                    }
                    updater(data, t);
                    ImmutableEmptyCellDataImpl immutableEmptyCellData = ImmutableEmptyCellDataImpl.Instance;
                    if (data.IsEqual(immutableEmptyCellData))
                    {
                        return immutableEmptyCellData;
                    }
                    return data;
                }
                else if (data.IsMutable)
                {
                    updater(data, t);
                    return data;
                }
                else
                {
                    ICellData mutableData = MutableCellDataImpl.Copy(data);
                    updaterFunc(mutableData, t);
                    return mutableData;
                }
            }
            IOneBasedArray2D<ICellData> newCellDataArray = cellDataArray.ZipArray(updaterFunc, dataToSet);
            _parent.BackingData.SetArea(newCellDataArray.ZeroBasedEquivalent, _startRow, _startCol);
        }

        private void ValidateSize<T>(IOneBasedArray2D<T> dataToSet)
        {
            int rowCount = dataToSet.GetLength(0);
            int colCount = dataToSet.GetLength(1);
            int thisRowCount = _endRow - _startRow;
            int thisColCount = _endCol - _startCol;
            //TODO
        }

        private IOneBasedArray2D<ICellData> GetCellDataArray()
        {
            return CsharpExtrasApi.NewOneBasedArray2D(
                            _parent.BackingData.GetArea(_startRow, _startCol, _endRow, _endCol));
        }
    }
}
