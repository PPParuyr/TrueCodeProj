using System;
using System.IO;
using System.Text;

public class MessageReader
{
    private readonly Stream _stream;
    private readonly byte _delimiter;

    public MessageReader(Stream stream, byte delimiter)
    {
        _stream = stream ?? throw new ArgumentNullException(nameof(stream));
        _delimiter = delimiter;
    }

    public string ReadNextMessage()
    {
        using (MemoryStream messageStream = new MemoryStream())
        {
            int currentByte;
            while ((currentByte = _stream.ReadByte()) != -1)
            {
                if (currentByte == _delimiter)
                {
                    return Encoding.UTF8.GetString(messageStream.ToArray());
                }
                else
                {
                    messageStream.WriteByte((byte)currentByte);
                }
            }

            return null;
        }
    }
}
