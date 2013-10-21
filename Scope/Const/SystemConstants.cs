using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scope.Const
{
    /// <summary>
    /// システム共通の定数クラス
    /// </summary>
    public class SystemConstants
    {
        /// <summary>
        /// セッションに利用するキーを設定する
        /// </summary>
        public class SessionKey
        {

            public const String USER_INFO = "session_userinfo";
        }

        /// <summary>
        /// View層で利用する定数を定義する。
        /// </summary>
        public class ViewLayerConstants
        {
            /// <summary>
            /// DropDownListの未選択値を表すValue
            /// </summary>
            public const String EMPTY_DRPDWN_VALUE = "0";

            /// <summary>
            /// DropDownListの未選択を表すText
            /// </summary>
            public const String EMPTY_DRPDWN_TEXT = "---選択してください---";
        }
    }
}