using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ApiCore
{
    public static class XmlUtils
    {
        private static XmlNode node;

        /// <summary>
        /// Set active node
        /// </summary>
        /// <param name="node">node to be used as active</param>
        public static void UseNode(XmlNode node)
        {
            XmlUtils.node = node;
        }

		public static string GetString(string nodeName, XmlNode innerNode)
		{
			XmlNode selectSingleNode = innerNode.SelectSingleNode(nodeName);
			return selectSingleNode != null ? selectSingleNode.InnerText.Replace("&lt;br&gt;", "\r\n") : null;
		}

        /// <summary>
        /// Gets the string value from node
        /// </summary>
        /// <param name="nodeName">node</param>
        /// <returns>string</returns>
        public static string String(string nodeName)
        {
			return GetString(nodeName, node);
        }

        public static string StringVal()
        {
            if (XmlUtils.node != null)
            {
                return XmlUtils.node.InnerText.Replace("&lt;br&gt;", "\r\n");
            }
            return "";
        }

		public static int GetInt(string nodeName, XmlNode innerNode)
		{
			XmlNode singleNode = innerNode.SelectSingleNode(nodeName);
			return singleNode != null ? Convert.ToInt32(singleNode.InnerText) : -1;
		}

        /// <summary>
        /// Gets the int value from node
        /// </summary>
        /// <param name="nodeName">node</param>
        /// <returns>int</returns>
        public static int Int(string nodeName)
        {
			return GetInt(nodeName, node);
        }

        public static int IntVal()
        {
            if (XmlUtils.node != null)
            {
                return Convert.ToInt32(XmlUtils.node.InnerText) ;
            }
            return -1;
        }

        /// <summary>
        /// Gets double value from node
        /// </summary>
        /// <param name="nodeName">node</param>
        /// <param name="innerNode"></param>
        /// <returns>double</returns>
        public static double GetDouble(string nodeName, XmlNode innerNode)
        {
		    XmlNode singleNode = innerNode.SelectSingleNode(nodeName);
		    return singleNode != null ? Convert.ToDouble(singleNode.InnerText) : -1f;
        }

		public static float GetFloat(string nodeName, XmlNode innerNode)
		{
			XmlNode singleNode = innerNode.SelectSingleNode(nodeName);
			return singleNode != null ? float.Parse(singleNode.InnerText) : -1f;
		}

        /// <summary>
        /// Gets float value from node
        /// </summary>
        /// <param name="nodeName">node</param>
        /// <returns>float</returns>
        public static float Float(string nodeName)
        {
            return GetFloat(nodeName, node);
        }

        public static float FloatVal()
        {
            if (XmlUtils.node != null)
            {
                return (float)Convert.ToDouble(XmlUtils.node.InnerText);
            }
            return -1f;
        }

		public static bool GetBool(string nodeName, XmlNode innerNode)
		{
			XmlNode singleNode = innerNode.SelectSingleNode(nodeName);
			return singleNode != null && singleNode.InnerText == "1";
		}

        /// <summary>
        /// Gets the bool value from node
        /// </summary>
        /// <param name="nodeName">node</param>
        /// <returns>true or false</returns>
        public static bool Bool(string nodeName)
        {
            return GetBool(nodeName, node);
        }

        public static bool BoolVal()
        {
            if (XmlUtils.node != null)
            {
                return ((XmlUtils.node.InnerText == "1") ? true : false);
            }
            return false;
        }
    }
}
