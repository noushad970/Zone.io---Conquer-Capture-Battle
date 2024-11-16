// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("66I+aEVhePVtjJr5y4W4o9mACCPyxU7WVHlQq/Xh/xr0Vrc9druZUXz/8f7OfP/0/Hz///5X4eqv62IEKQy6tTUaPOcDCnXhfpexKKsGZi722e/iIP361sF4HX8qQLcXNiRYjM/hAK2RAr36FQkPEo4yu58nFN0u9AqCvYh7MKQSvFh6UaqtspqESZ3OfP/czvP499R4tngJ8/////v+/ZhXGHPN9pxud55n61Cx27TliAVaKWRRr+hubJ96YUMGgffycBFZea1kEBtK4P/cCeM2Vs2UbMkoxVsmsECQH+sUM8JYxl9/U7WqYP1S++ulJoUl6pOwpraXGdW0SGa0/stJyXm8dk809uxoKcgCYe967UJZ96Cc8dr6COPiomx2z/z9//7/");
        private static int[] order = new int[] { 3,11,11,5,10,9,7,9,11,13,10,13,13,13,14 };
        private static int key = 254;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
