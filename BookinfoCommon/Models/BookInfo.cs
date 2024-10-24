using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookinfoCommon.Models
{
   

    public class BookInfo
    {
        public Book book { get; set; }
        public Comment[] comments { get; set; }
        public int commentsCount { get; set; }
        public Relatedbook[] relatedBooks { get; set; }
        public string shareText { get; set; }
        public Quote[] quotes { get; set; }
        public int quotesCount { get; set; }
        public bool hideOffCoupon { get; set; }
    }

    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public int sourceBookId { get; set; }
        public bool index { get; set; }
        public bool hasPhysicalEdition { get; set; }
        public int canonicalId { get; set; }
        public DateTime lastUpdate { get; set; }
        public string description { get; set; }
        public string htmlDescription { get; set; }
        public string jsonDescription { get; set; }
        public string faqs { get; set; }
        public int PublisherID { get; set; }
        public string publisherSlug { get; set; }
        public float price { get; set; }
        public int numberOfPages { get; set; }
        public float rating { get; set; }
        public Rate[] rates { get; set; }
        public Ratedetail[] rateDetails { get; set; }
        public Type[] types { get; set; }
        public string sticker { get; set; }
        public int beforeOffPrice { get; set; }
        public bool isRtl { get; set; }
        public bool showOverlay { get; set; }
        public string ISBN { get; set; }
        public string publishDate { get; set; }
        public int destination { get; set; }
        public string type { get; set; }
        public string refId { get; set; }
        public string coverUri { get; set; }
        public string shareUri { get; set; }
        public string shareText { get; set; }
        public string publisher { get; set; }
        public Author[] authors { get; set; }
        public File[] files { get; set; }
        public Label[] labels { get; set; }
        public Category[] categories { get; set; }
        public bool subscriptionAvailable { get; set; }
        public int state { get; set; }
        public bool encrypted { get; set; }
        public float currencyPrice { get; set; }
        public float currencyBeforeOffPrice { get; set; }
        public int sumDurationSeconds { get; set; }
        public int rateCounts { get; set; }
        public bool isEpub { get; set; }
    }

    public class Rate
    {
        public float value { get; set; }
        public int count { get; set; }
    }

    public class Ratedetail
    {
        public int id { get; set; }
        public string title { get; set; }
        public float point { get; set; }
    }

    public class Type
    {
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public float beforeOffPrice { get; set; }
    }

    public class Author
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int type { get; set; }
        public string slug { get; set; }
    }

    public class File
    {
        public int id { get; set; }
        public int size { get; set; }
        public int type { get; set; }
        public int bookId { get; set; }
        public int sequenceNo { get; set; }
    }

    public class Label
    {
        public int tagID { get; set; }
        public string tag { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public int parent { get; set; }
        public string title { get; set; }
        public string audioTitle { get; set; }
        public string slug { get; set; }
        public string audioSlug { get; set; }
        public bool hasAudioSection { get; set; }
        public int firstAudioVisibleId { get; set; }
    }

    public class Comment
    {
        public int id { get; set; }
        public int accountId { get; set; }
        public bool verifiedAccount { get; set; }
        public string nickname { get; set; }
        public string profileImageUri { get; set; }
        public int bookId { get; set; }
        public string bookCoverUri { get; set; }
        public string bookType { get; set; }
        public string bookName { get; set; }
        public string creationDate { get; set; }
        public float rate { get; set; }
        public Latestreply[] latestReplies { get; set; }
        public int repliesCount { get; set; }
        public int likeCount { get; set; }
        public int dislikeCount { get; set; }
        public string comment { get; set; }
        public bool isLiked { get; set; }
        public bool isDisliked { get; set; }
        public Ratedetail1[] rateDetails { get; set; }
        public int recommendation { get; set; }
    }

    public class Latestreply
    {
        public int id { get; set; }
        public int accountId { get; set; }
        public bool verifiedAccount { get; set; }
        public string nickname { get; set; }
        public string profileImageUri { get; set; }
        public int bookId { get; set; }
        public string bookCoverUri { get; set; }
        public string bookType { get; set; }
        public string bookName { get; set; }
        public string creationDate { get; set; }
        public float rate { get; set; }
        public int repliesCount { get; set; }
        public int likeCount { get; set; }
        public int dislikeCount { get; set; }
        public string comment { get; set; }
        public bool isLiked { get; set; }
        public bool isDisliked { get; set; }
        public object[] rateDetails { get; set; }
        public int recommendation { get; set; }
    }

    public class Ratedetail1
    {
        public int id { get; set; }
        public string title { get; set; }
        public float point { get; set; }
    }

    public class Relatedbook
    {
        public int type { get; set; }
        public string title { get; set; }
        public int backgroundStyle { get; set; }
        public Bookdata bookData { get; set; }
        public Destination destination { get; set; }
        public Backgroundconfig backgroundConfig { get; set; }
    }

    public class Bookdata
    {
        public Book1[] books { get; set; }
        public int layout { get; set; }
        public bool showPrice { get; set; }
    }

    public class Book1
    {
        public int id { get; set; }
        public string title { get; set; }
        public int sourceBookId { get; set; }
        public bool index { get; set; }
        public bool hasPhysicalEdition { get; set; }
        public int canonicalId { get; set; }
        public string subtitle { get; set; }
        public DateTime lastUpdate { get; set; }
        public string description { get; set; }
        public string htmlDescription { get; set; }
        public int PublisherID { get; set; }
        public string publisherSlug { get; set; }
        public float price { get; set; }
        public int numberOfPages { get; set; }
        public Rate1[] rates { get; set; }
        public Ratedetail2[] rateDetails { get; set; }
        public Type1[] types { get; set; }
        public int beforeOffPrice { get; set; }
        public bool isRtl { get; set; }
        public bool showOverlay { get; set; }
        public string ISBN { get; set; }
        public string publishDate { get; set; }
        public int destination { get; set; }
        public string type { get; set; }
        public string refId { get; set; }
        public string coverUri { get; set; }
        public string shareUri { get; set; }
        public string shareText { get; set; }
        public string publisher { get; set; }
        public Author1[] authors { get; set; }
        public File1[] files { get; set; }
        public Label1[] labels { get; set; }
        public Category1[] categories { get; set; }
        public bool subscriptionAvailable { get; set; }
        public int state { get; set; }
        public bool encrypted { get; set; }
        public float currencyPrice { get; set; }
        public float currencyBeforeOffPrice { get; set; }
        public int sumDurationSeconds { get; set; }
        public int rateCounts { get; set; }
        public bool isEpub { get; set; }
        public float rating { get; set; }
        public int PhysicalPrice { get; set; }
        public string sticker { get; set; }
        public string offText { get; set; }
        public string priceColor { get; set; }
    }

    public class Rate1
    {
        public float value { get; set; }
        public int count { get; set; }
    }

    public class Ratedetail2
    {
        public int id { get; set; }
        public string title { get; set; }
        public float point { get; set; }
    }

    public class Type1
    {
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public float beforeOffPrice { get; set; }
    }

    public class Author1
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int type { get; set; }
        public string slug { get; set; }
    }

    public class File1
    {
        public int id { get; set; }
        public int size { get; set; }
        public int type { get; set; }
        public int bookId { get; set; }
        public int sequenceNo { get; set; }
        public string title { get; set; }
    }

    public class Label1
    {
        public int tagID { get; set; }
        public string tag { get; set; }
    }

    public class Category1
    {
        public int id { get; set; }
        public int parent { get; set; }
        public string title { get; set; }
        public string audioTitle { get; set; }
        public string slug { get; set; }
        public string audioSlug { get; set; }
        public bool hasAudioSection { get; set; }
        public int firstAudioVisibleId { get; set; }
        public string icon { get; set; }
    }

    public class Destination
    {
        public int type { get; set; }
        public int order { get; set; }
        public int navigationPage { get; set; }
        public int operationType { get; set; }
        public int bookId { get; set; }
        public string pageTitle { get; set; }
        public Filters filters { get; set; }
    }

    public class Filters
    {
        public List[] list { get; set; }
        public string refId { get; set; }
    }

    public class List
    {
        public int type { get; set; }
        public int value { get; set; }
    }

    public class Backgroundconfig
    {
        public int style { get; set; }
    }

    public class Quote
    {
        public string id { get; set; }
        public Data data { get; set; }
        public int likeCount { get; set; }
        public int bookId { get; set; }
        public int accountId { get; set; }
        public int commentCount { get; set; }
        public string creationDate { get; set; }
        public DateTime date { get; set; }
        public bool showComment { get; set; }
        public string coverUri { get; set; }
        public string bookName { get; set; }
        public string authorName { get; set; }
        public string publisherName { get; set; }
        public string profileImageUri { get; set; }
        public string nickname { get; set; }
        public string description { get; set; }
    }

    public class Data
    {
        public string quote { get; set; }
        public int startAtomId { get; set; }
        public int endAtomId { get; set; }
        public int chapterIndex { get; set; }
        public int endOffset { get; set; }
        public int startOffset { get; set; }
    }

}
