using CsharpExtras.Event.Notify;
using CsharpExtras.Event.Wrapper;
using CsharpExtras.Map.Sparse.TwoDimensional;
using CsharpExtras.Map.Sparse.TwoDimensional.Builder;
using CsharpExtras.ValidatedType.Numeric.Integer;
using ExcelMock._base;
using ExcelMock.mock.interop.worksheet.partial.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.mock.interop.worksheet.partial.builder
{
    internal class PartialSheetArrayBuilderImpl : BaseClass, IPartialSheetArrayBuilder
    {
        private ISparseArray2D<string>? _valuesArray;
        private ISparseArray2D<string> ValuesArray => _valuesArray ??=
            NewSparseStringArrayWithValidations();

        private ISparseArray2D<string>? _formulasArray;
        private ISparseArray2D<string> FormulasArray => _formulasArray ??=
            NewSparseStringArrayWithValidations();

        public ISparseArray2D<ICellData> Build()
        {
            ICellData defaultEmptyData = EmptyCellDataImpl.Instance;
            ISparseArray2D<ICellData> resultantArray = FormulasArray.Zip
                ((f, v) => new MutableCellDataImpl(f, v),
                ValuesArray, defaultEmptyData, (k, i) => i > 0);
            return resultantArray;
        }

        public IPartialSheetArrayBuilder WithValues(int row, int column, string[,] values)
        {
            UpdateSparseArray(ValuesArray, row, column, values);
            return this;
        }

        public IPartialSheetArrayBuilder WithFormulas(int row, int column, string[,] formulas)
        {
            UpdateSparseArray(FormulasArray, row, column, formulas);
            return this;
        }

        private void UpdateSparseArray<T>(ISparseArray2D<T> array, int row, int column, T[,] area)
        {
            try
            {
                array.SetArea(area, row, column);
            }
            catch(IndexOutOfRangeException ex)
            {
                throw new ArgumentException($"(Row, column) is invalid: ({row}, {column})",
                    ex);
            }
        }

        private ISparseArray2D<string> NewSparseStringArrayWithValidations() =>
            NewSparseArrayWithValidations("");

        private ISparseArray2D<T> NewSparseArrayWithValidations<T>(T defaultVal)
        {
            ISparseArray2DBuilder<T> builder = CsharpExtrasApi.NewSparseArray2DBuilder(defaultVal)
                .WithRowValidation(i => i > 0)
                .WithColumnValidation(i => i > 0);
            return builder.Build();
        }

    }
}
