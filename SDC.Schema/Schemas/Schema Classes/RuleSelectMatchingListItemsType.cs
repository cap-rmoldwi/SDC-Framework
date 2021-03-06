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

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:ihe:qrph:sdc:2016")]
public partial class RuleSelectMatchingListItemsType : ExtensionBaseType
{
    
    #region Private fields
    private ItemNameAttributeType _matchSource;
    
    private RuleListItemMatchTargetsType _listItemMatchTargets;
    #endregion
    
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public virtual ItemNameAttributeType MatchSource
    {
        get
        {
            return this._matchSource;
        }
        set
        {
            if ((this._matchSource == value))
            {
                return;
            }
            if (((this._matchSource == null) 
                        || (_matchSource.Equals(value) != true)))
            {
                this._matchSource = value;
                this.OnPropertyChanged("MatchSource", value);
            }
        }
    }
    
    [System.Xml.Serialization.XmlElementAttribute(Order=1)]
    public virtual RuleListItemMatchTargetsType ListItemMatchTargets
    {
        get
        {
            return this._listItemMatchTargets;
        }
        set
        {
            if ((this._listItemMatchTargets == value))
            {
                return;
            }
            if (((this._listItemMatchTargets == null) 
                        || (_listItemMatchTargets.Equals(value) != true)))
            {
                this._listItemMatchTargets = value;
                this.OnPropertyChanged("ListItemMatchTargets", value);
            }
        }
    }
    
    /// <summary>
    /// Test whether MatchSource should be serialized
    /// </summary>
    public virtual bool ShouldSerializeMatchSource()
    {
        return (_matchSource != null);
    }
    
    /// <summary>
    /// Test whether ListItemMatchTargets should be serialized
    /// </summary>
    public virtual bool ShouldSerializeListItemMatchTargets()
    {
        return (_listItemMatchTargets != null);
    }
}
}
#pragma warning restore
