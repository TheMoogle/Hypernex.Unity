// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
#pragma warning disable CS1591 // document public APIs

#pragma warning disable SA1129 // Do not use default value type constructor
#pragma warning disable SA1309 // Field names should not begin with underscore
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
#pragma warning disable SA1403 // File may only contain a single namespace
#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters.Hypernex.Networking.Messages
{
    public sealed class PlayerDataUpdateFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Hypernex.Networking.Messages.PlayerDataUpdate>
    {

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Hypernex.Networking.Messages.PlayerDataUpdate value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
                return;
            }

            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            writer.WriteArrayHeader(5);
            writer.WriteNil();
            writer.WriteNil();
            global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Hypernex.Networking.Messages.JoinAuth>(formatterResolver).Serialize(ref writer, value.Auth, options);
            global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::System.Collections.Generic.Dictionary<string, object>>(formatterResolver).Serialize(ref writer, value.ExtraneousData, options);
            global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::System.Collections.Generic.List<string>>(formatterResolver).Serialize(ref writer, value.PlayerAssignedTags, options);
        }

        public global::Hypernex.Networking.Messages.PlayerDataUpdate Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            var length = reader.ReadArrayHeader();
            var ____result = new global::Hypernex.Networking.Messages.PlayerDataUpdate();

            for (int i = 0; i < length; i++)
            {
                switch (i)
                {
                    case 2:
                        ____result.Auth = global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Hypernex.Networking.Messages.JoinAuth>(formatterResolver).Deserialize(ref reader, options);
                        break;
                    case 3:
                        ____result.ExtraneousData = global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::System.Collections.Generic.Dictionary<string, object>>(formatterResolver).Deserialize(ref reader, options);
                        break;
                    case 4:
                        ____result.PlayerAssignedTags = global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::System.Collections.Generic.List<string>>(formatterResolver).Deserialize(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;
            return ____result;
        }
    }

}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning restore SA1129 // Do not use default value type constructor
#pragma warning restore SA1309 // Field names should not begin with underscore
#pragma warning restore SA1312 // Variable names should begin with lower-case letter
#pragma warning restore SA1403 // File may only contain a single namespace
#pragma warning restore SA1649 // File name should match first type name
