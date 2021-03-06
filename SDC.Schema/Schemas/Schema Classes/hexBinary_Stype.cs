// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code++. Version 5.1.87.0. www.xsd2code.com
//  </auto-generated>
// ------------------------------------------------------------------------------
#pragma warning disable
namespace SDC.Schema
{
using System;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections;
using System.Xml.Schema;
using System.ComponentModel;
using System.Xml;
using System.IO;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

[System.Xml.Serialization.XmlIncludeAttribute(typeof(hexBinary_DEtype))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:ihe:qrph:sdc:2016")]
public partial class hexBinary_Stype : BaseType
{
    
    #region Private fields
    private string _mimeType;
    
    private byte[] _val;
    #endregion
    
    /// <summary>
    /// TBD: Must be a valid MIME type - needs
    /// enumeration
    /// </summary>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public virtual string mimeType
    {
        get
        {
            return this._mimeType;
        }
        set
        {
            if ((this._mimeType == value))
            {
                return;
            }
            if (((this._mimeType == null) 
                        || (_mimeType.Equals(value) != true)))
            {
                this._mimeType = value;
                this.OnPropertyChanged("mimeType", value);
            }
        }
    }
    
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="hexBinary")]
    public virtual byte[] val
    {
        get
        {
            return this._val;
        }
        set
        {
            if ((this._val == value))
            {
                return;
            }
            if (((this._val == null) 
                        || (_val.Equals(value) != true)))
            {
                this._val = value;
                this.OnPropertyChanged("val", value);
            }
        }
    }
    
    /// <summary>
    /// Test whether mimeType should be serialized
    /// </summary>
    public virtual bool ShouldSerializemimeType()
    {
        return !string.IsNullOrEmpty(mimeType);
    }
}
}
#pragma warning restore
