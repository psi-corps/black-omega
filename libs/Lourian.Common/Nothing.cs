namespace Lourian.Common
{
    using System;
    using System.Runtime.CompilerServices;

    
    
    /// <inheritdoc cref="ValueType" />
    /// <summary>
    /// Да, это -- структура, которая представляет "ничего".
    /// Совершенно в прямом смысле -- ничего.
    ///
    /// То есть вот есть "Null Object" из GoF, а это вот такой вот "Null Type".
    ///
    /// Он сделан для того, чтобы, например, использовать в generic-параметрах, когда тебе, мой друг,
    /// совершенно по боку, какого он типа, а object использовать не хочется, ну потому что мало ли,
    /// кто вместо него что-то передаст? Вот вызовется где-нибудь на нем ToString() или GetHashCode(), а там...
    /// Или потому что инстанс этого самого параметра является полем объекта, а нам внезапно на него начхать.
    ///
    /// Да, друг, залатывать этим дыры в архитектуре не стоит, да, я в курсе, что можно параметризовать
    /// generic типом object и хранить в поле объекта значение <langword name="null"/>....
    ///
    /// "Но есть ньюанс (с)": эта структура не занимает памяти вообще. То есть это и правда "ничего".
    ///  </summary>
    public readonly struct Nothing
    {
        #region ValueType
        
        /// <inheritdoc cref="ValueType.Equals(object)"/>.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => false;

        /// <inheritdoc cref="ValueType.GetHashCode"/>.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => 0;
        
        
        /// <inheritdoc cref="ValueType.ToString"/>.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => nameof(Nothing);
        
        #endregion
    }
}