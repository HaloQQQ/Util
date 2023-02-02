﻿using Util.Ui.Angular.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Forms.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.Label.Builders {
    /// <summary>
    /// 标签生成器
    /// </summary>
    public class LabelBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public LabelBuilder( Config config ) : base( config, "span" ) {
            _config = config;
        }

        /// <summary>
        /// 配置文本
        /// </summary>
        public LabelBuilder Text() {
            return SetText( _config.GetValue( UiConst.Text ) );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        private LabelBuilder SetText( string value ) {
            var options = NgZorroOptionsService.GetOptions();
            if ( value.IsEmpty() )
                return this;
            if ( options.EnableI18n ) {
                this.AppendContentByI18n( value );
                return this;
            }
            AppendContent( value );
            return this;
        }

        /// <inheritdoc />
        public override void Config() {
            base.Config();
            Text();
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( Config config ) {
            if ( config.Content.IsEmpty() == false ) {
                config.Content.AppendTo( this );
                return;
            }
            ConfigValue();
        }

        /// <summary>
        /// 配置值
        /// </summary>
        private void ConfigValue() {
            var value = _config.GetValue( UiConst.Value );
            SetContent( value );
        }
    }
}
