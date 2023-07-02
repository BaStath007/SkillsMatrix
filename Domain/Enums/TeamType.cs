using Domain.Primitives;

namespace Domain.Enums;

public abstract class TeamType : Enumeration<TeamType>
{
    protected TeamType(int value, string name)
        : base(value, name)
    {
    }

    public abstract List<string> Characteristics { get; }


    public static readonly TeamType None = new NoneTeamType();
    public static readonly TeamType Backend = new BackendTeamType();
    public static readonly TeamType Frontend = new FrontendTeamType();
    public static readonly TeamType Database = new DatabaseTeamType();
    public static readonly TeamType SQA = new SQATeamType();


    private sealed class NoneTeamType : TeamType
    {
        public NoneTeamType()
            : base(0, "None")
        {
        }

        public override List<string> Characteristics => new();
    }

    private sealed class BackendTeamType : TeamType
    {
        public BackendTeamType()
            : base(1, "Backend")
        {
        }

        public override List<string> Characteristics => 
            new()
            {
                "Backend teams consist of skilled software engineers,that possess " +
                "a deep understanding of databases, server-side frameworks, and other backend technologies.",
                "Backend teams are responsible for designing and implementing the architecture of the software system.",
                "Backend teams develop and maintain application programming interfaces (APIs) that allow " +
                "communication between different components of a software system.",
                "Backend teams focus on optimizing the performance of the software system.",
                "Backend teams play a vital role in ensuring the security of the system. They implement " +
                "authentication mechanisms, data encryption, and handle user access controls."
            };
    }

    private sealed class FrontendTeamType : TeamType
    {
        public FrontendTeamType()
            : base(2, "Frontend")
        {
        }

        public override List<string> Characteristics =>
            new()
            {
                "Frontend teams are well-versed in web technologies such as HTML, CSS, and JavaScript. They " +
                "have a deep understanding of frontend frameworks and libraries like React, Angular, or " +
                "Vue.js that enable them to build interactive and responsive UI components.",
                "Frontend teams collaborate with UI/UX designers to create visually appealing and user-friendly interfaces.",
                "Frontend teams consider cross-browser compatibility to ensure that the application functions and appears " +
                "consistently across different web browsers such as Chrome, Firefox, Safari, and Edge. They test and debug " +
                "any issues specific to different browser environments.",
                "Frontend teams optimize the performance of the application by minimizing file sizes, reducing the number " +
                "of HTTP requests, and employing techniques like lazy loading and caching. They aim to deliver fast-loading " +
                "and smooth user experiences."
            };
    }

    private sealed class DatabaseTeamType : TeamType
    {
        public DatabaseTeamType()
            : base(3, "Database")
        {
        }

        public override List<string> Characteristics =>
            new()
            {
                "Database teams develop and implement data governance frameworks and strategies.",
                "Database teams are focused on maintaining data quality.",
                "Database teams prioritize data security and privacy.",
                "Database teams are involved in designing and maintaining the organization's data architecture.",
                "Database teams handle data integration processes and Extract, Transform, Load (ETL) operations.",
                "Database teams collaborate with data analysts and business intelligence teams to support data analytics " +
                "and reporting needs.",
                "Database teams maintain data dictionaries, data lineage documentation, and metadata repositories.",
                "Database teams oversee the entire data lifecycle from data acquisition and ingestion to archival or deletion."
            };
    }

    private sealed class SQATeamType : TeamType
    {
        public SQATeamType()
            : base(4, "SQA")
        {
        }

        public override List<string> Characteristics =>
            new()
            {
                "SQA teams develop test plans and strategies based on project requirements and specifications. They identify " +
                "test objectives, define test coverage, and determine appropriate testing methodologies.",
                "SQA teams create test cases, test scenarios, and test scripts to validate the functionality, performance, " +
                "and usability of software systems. They execute various types of testing, such as functional testing, " +
                "integration testing, regression testing, performance testing, and user acceptance testing.",
                "SQA teams leverage automation tools and frameworks to automate repetitive and time-consuming testing tasks.",
                "SQA teams track and manage software defects. They identify, log, prioritize, and track defects through resolution.",
                "SQA teams set up and manage test environments that closely resemble the production environment.",
                "SQA teams conduct performance and load testing to assess system performance, scalability, and " +
                "reliability under various conditions.",
                "SQA teams perform security testing to identify vulnerabilities and ensure the security of software systems. " +
                "They conduct penetration testing, vulnerability assessments, and security code reviews to identify potential " +
                "risks and recommend security enhancements.",
                "SQA teams adhere to quality standards and industry best practices. They ensure compliance with relevant regulations, " +
                "standards, and frameworks applicable to the software systems being developed or maintained."
            };
    }
}
